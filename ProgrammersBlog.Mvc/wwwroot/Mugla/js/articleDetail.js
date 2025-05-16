$(document).ready(function() {
    // Yanıtları aç/kapa butonu için
    $(document).on('click', '.toggle-replies', function(e) {
        e.preventDefault();
        const $button = $(this);
        const commentId = $button.data('comment-id');
        const $replies = $button.closest('.comment-card').find('.replies');
        const $icon = $button.find('.toggle-icon');
        const $text = $button.find('.toggle-text');

        if ($replies.is(':visible')) {
            $replies.slideUp(300);
            $icon.removeClass('bi-chevron-up').addClass('bi-chevron-down');
            $text.text('Yanıtları göster');
        } else {
            $replies.slideDown(300);
            $icon.removeClass('bi-chevron-down').addClass('bi-chevron-up');
            $text.text('Yanıtları gizle');
        }
    });

    // Devamını göster/gizle butonu için
    $(document).on('click', '.toggle-text', function(e) {
        e.preventDefault();
        const $button = $(this);
        const $content = $button.closest('.comment-content');
        const $shortText = $content.find('.short-text');
        const $fullText = $content.find('.full-text');

        if ($shortText.is(':visible')) {
            $shortText.hide();
            $fullText.show();
            $button.text('Daha az göster');
        } else {
            $shortText.show();
            $fullText.hide();
            $button.text('Devamını göster');
        }
    });

    // Renk paleti
    const colorPalettes = [
        { bg: '#fce4ec', text: '#c2185b' },  // Pembe
        { bg: '#e3f2fd', text: '#1565c0' },  // Mavi
        { bg: '#f3e5f5', text: '#7b1fa2' },  // Mor
        { bg: '#e8f5e9', text: '#2e7d32' },  // Yeşil
        { bg: '#fff3e0', text: '#ef6c00' },  // Turuncu
        { bg: '#edeef7', text: '#3949ab' },  // Kobalt
        { bg: '#f9fbe7', text: '#827717' },  // Zeytin
        { bg: '#ffebee', text: '#d81b60' },  // Fuşya
        { bg: '#e0f2f1', text: '#00796b' },  // Teal
        { bg: '#e1f5fe', text: '#0288d1' }   // Gök Mavi
    ];
    
    // Toastr ayarları
    toastr.options = {
        "closeButton": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "timeOut": 5000
    };
    
    console.log('ArticleDetail.js yüklendi');
    
    // Sayfa yüklendiğinde tüm token'ları göster
    $('input[name="__RequestVerificationToken"]').each(function(index) {
        console.log(`Token ${index}:`, $(this).val());
    });
    
    // Ana token
    const mainToken = $('input[name="__RequestVerificationToken"]').first().val();
    console.log('Ana token:', mainToken);
    
    // Yanıtla butonuna tıklandığında
    $(document).on('click', '.reply-button', function(e) {
        e.preventDefault();
        console.log('Yanıtla butonuna tıklandı');
        const commentId = $(this).data('comment-id');
        console.log('Yorum ID:', commentId);
        
        // Diğer tüm yanıt formlarını kapat
        $('.reply-form').not(`#reply-form-${commentId}`).slideUp();
        
        // Bu yoruma ait yanıt formunu aç/kapat
        const replyForm = $(`#reply-form-${commentId}`);
        console.log('Yanıt formu bulundu mu:', replyForm.length > 0);
        if (replyForm.length > 0) {
            replyForm.slideToggle();
        } else {
            console.error(`Yanıt formu bulunamadı: #reply-form-${commentId}`);
        }
    });
    
    // İptal butonuna tıklandığında
    $(document).on('click', '.cancel-reply', function(e) {
        e.preventDefault();
        $(this).closest('.reply-form').slideUp();
    });
    
    // Yanıt gönder butonuna tıklandığında
    $(document).on('click', '.send-reply', function(e) {
        e.preventDefault();
        console.log('Yanıt gönder butonuna tıklandı');
        
        const $this = $(this);
        const $form = $this.closest('form');
        const parentId = $form.data('parent-id');
        const articleId = $form.find('input[name="ArticleId"]').val();
        const createdByName = $form.find('input[name="CreatedByName"]').val();
        const text = $form.find('textarea[name="Text"]').val();
        const $replyForm = $this.closest('.reply-form');
        
        console.log('Yanıt verileri:', {
            parentId,
            articleId,
            createdByName,
            text
        });
        
        // Validasyon
        if (!createdByName || !text) {
            toastr.error('Lütfen tüm alanları doldurun.', 'Hata!');
            return;
        }
        
        // CSRF token
        const token = $('input[name="__RequestVerificationToken"]').first().val();
        
        // jQuery AJAX ile yanıt gönderme işlemi
        $.ajax({
            url: '/Comment/AddReply',
            type: 'POST',
            data: {
                ParentCommentId: parentId,
                ArticleId: articleId,
                CreatedByName: createdByName,
                Text: text
            },
            headers: {
                'RequestVerificationToken': token
            },
            success: function(data) {
                console.log('Yanıt gönderme yanıtı:', data);
                
                try {
                    const response = typeof data === 'string' ? JSON.parse(data) : data;
                    
                    if (response.success) {
                        toastr.success(response.message, 'Başarılı');
                        $form[0].reset();
                        $replyForm.slideUp();
                        return;
                    } else {
                        toastr.error(response.message || 'Bir hata oluştu', 'Hata!');
                        return;
                    }
                    
                    // Yanıtı uygun yere ekle
                    if (commentAddAjaxModel.CommentDto.Comment.ParentCommentId) {
                        // Bu bir yanıt - ana yorumu bul
                        const $parentComment = $(`[data-comment-id="${commentAddAjaxModel.CommentDto.Comment.ParentCommentId}"]`);
                        
                        if (!$parentComment.length) {
                            console.error('Ana yorum bulunamadı:', commentAddAjaxModel.CommentDto.Comment.ParentCommentId);
                            return;
                        }
                        
                        // Ana yorumun altında replies div'i var mı kontrol et
                        let $replies = $parentComment.find('.replies');
                        if ($replies.length === 0) {
                            // Yoksa oluştur
                            $replies = $('<div class="replies ms-4 mt-3"></div>');
                            $parentComment.find('.card-body').append($replies);
                        }
                        
                        // Ana yorumun renk paletini al
                        const parentBgColor = $parentComment.find('.card-body').css('background-color');
                        const parentTextColor = $parentComment.find('.fw-bold').first().css('color');
                        const palette = { bg: parentBgColor, text: parentTextColor };
                        
                        // Yanıtı oluştur
                        const $newReply = $(`
                            <div class="card mb-2 border-start border-2 reply-card" 
                                 style="border-color: ${palette.text} !important; background-color: ${palette.bg};">
                                <div class="card-body py-2 px-3">
                                    <div class="d-flex align-items-center mb-1">
                                        <div class="text-white rounded-circle d-flex align-items-center justify-content-center me-2 reply-avatar"
                                             style="width: 30px; height: 30px; background-color: ${palette.text}; font-size: 0.8rem;">
                                            ${commentAddAjaxModel.CommentDto.Comment.CreatedByName[0].toUpperCase()}
                                        </div>
                                        <div>
                                            <h6 class="mb-0 fs-6 fw-bold" style="color: ${palette.text};">
                                                ${commentAddAjaxModel.CommentDto.Comment.CreatedByName}
                                            </h6>
                                            <small class="text-muted" style="font-size: 0.75rem;">Az önce</small>
                                        </div>
                                    </div>
                                    <p class="mb-1 ps-4 reply-text" style="font-size: 0.9rem;">
                                        ${commentAddAjaxModel.CommentDto.Comment.Text}
                                    </div>
                                </div>
                                <p class="mb-1 ps-4 reply-text" style="font-size: 0.9rem;">
                                    ${commentAddAjaxModel.CommentDto.Comment.Text}
                                </p>
                                <div class="d-flex mt-2 ps-4">
                                    <button class="btn btn-sm btn-link p-0 me-3 like-reply-button" 
                                            data-comment-id="${commentAddAjaxModel.CommentDto.Comment.Id}"
                                            style="color: ${palette.text}; font-size: 0.8rem;">
                                        <i class="bi bi-heart me-1"></i> Beğen <span class="like-count"></span>
                                    </button>
                                </div>
                            </div>
                        `);
                        
                        // Yanıt başarılı ise
                        if (response.success) {
                            // Yanıt - yanıt listesine ekle
                            const $replies = $(`#comment-${commentAddAjaxModel.CommentDto.Comment.ParentCommentId}`).find('.replies');
                            const palette = colorPalettes[Math.floor(Math.random() * colorPalettes.length)];
                            
                            const $newReply = $(`
                                <div class="card mb-2 border-start border-2 reply-card" 
                                     style="border-color: ${palette.text} !important; background-color: ${palette.bg};">
                                    <div class="card-body py-2 px-3">
                                        <div class="d-flex align-items-center mb-1">
                                            <div class="text-white rounded-circle d-flex align-items-center justify-content-center me-2 reply-avatar"
                                                 style="width: 30px; height: 30px; background-color: ${palette.text}; font-size: 0.8rem;">
                                                ${commentAddAjaxModel.CommentDto.Comment.CreatedByName[0].toUpperCase()}
                                            </div>
                                            <div>
                                                <h6 class="mb-0 fs-6 fw-bold" style="color: ${palette.text};">
                                                    ${commentAddAjaxModel.CommentDto.Comment.CreatedByName}
                                                </h6>
                                                <small class="text-muted" style="font-size: 0.75rem;">Şimdi</small>
                                            </div>
                                        </div>
                                        <div class="comment-content">
                                            <p class="mb-1 ps-4 reply-text" style="font-size: 0.9rem;">
                                                ${commentAddAjaxModel.CommentDto.Comment.Text}
                                            </p>
                                        </div>
                                        <div class="d-flex mt-2 ps-4">
                                            <button class="btn btn-sm btn-link p-0 me-3 like-reply-button" 
                                                    data-comment-id="${commentAddAjaxModel.CommentDto.Comment.Id}"
                                                    style="color: ${palette.text}; font-size: 0.8rem;">
                                                <i class="bi bi-heart me-1"></i> Beğen <span class="like-count">0</span>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            `);
                            
                            $replies.append($newReply);
                        }
                    }
                } catch (e) {
                    console.error('Parsing error:', e, 'Raw response:', data);
                    toastr.error('Beklenmeyen bir hata oluştu: ' + e.message, 'Hata');
                }
            },
            error: function(xhr, status, error) {
                console.error('Yanıt gönderme hatası:', error);
                toastr.error('Sunucuyla iletişim kurulamadı', 'Hata!');
            }
        });
    });
    
    $(document).on('click', '.like-reply-button', function(e) {
        e.preventDefault();
        console.log('Beğen butonuna tıklandı');
        
        const $this = $(this);
        const commentId = $this.data('comment-id');
        console.log('Beğenilen yorum ID:', commentId);
        
        const $icon = $this.find('i');
        const $count = $this.find('.like-count');
        
        // Aktif/pasif durumunu değiştir
        const isActive = $this.hasClass('active');
        
        // CSRF token
        const token = $('input[name="__RequestVerificationToken"]').first().val();
        console.log('Beğeni için gönderilen commentId:', commentId);
        
        // AJAX isteği
        const url = isActive ? '/Comment/UnlikeComment' : '/Comment/LikeComment';
        
        // jQuery AJAX kullanalım
        // Form verisi oluştur
        const formData = new FormData();
        formData.append('commentId', commentId);
        formData.append('__RequestVerificationToken', token);

        $.ajax({
            url: url, // isActive durumuna göre LikeComment veya UnlikeComment
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function(response) {
                console.log('Beğeni işlemi yanıtı:', response);
                
                // Yanıtı kontrol et
                if (response.success === true && typeof response.likeCount === 'number') {
                    // Beğeni sayısını güncelle
                    $count.text(response.likeCount > 0 ? response.likeCount : '');
                    
                    // Butonu güncelle
                    $this.toggleClass('active');
                    $icon.toggleClass('bi-heart bi-heart-fill');
                    
                    toastr.success('Beğeni işlemi başarılı!', 'Başarılı');
                } else {
                    toastr.error(response.message || 'Bir hata oluştu', 'Hata');
                }
            },
            error: function(xhr, status, error) {
                console.error('Beğeni işlemi hatası:', error);
                toastr.error('Sunucuyla iletişim kurulamadı', 'Hata!');
            }
        });
    });
    
    $(document).on('click', '#btnSave', function (event) {
        event.preventDefault();
        const form = $('#form-comment-add');
        const actionUrl = form.attr('action');
        const dataToSend = form.serialize();
        
        $.ajax({
            url: actionUrl,
            type: 'POST',
            data: dataToSend,
            headers: {
                'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
            },
            success: function (data) {
                try {
                    const commentAddAjaxModel = typeof data === 'string' ? JSON.parse(data) : data;

                    // Hata durumu kontrolü
                    if (!commentAddAjaxModel) {
                        toastr.error('Geçersiz sunucu yanıtı', 'Hata!');
                        return;
                    }

                    // Partial View güncelleme
                    if (commentAddAjaxModel.CommentAddPartial) {
                        const newFormBody = $(commentAddAjaxModel.CommentAddPartial).find('.form-card');
                        $('.form-card').replaceWith(newFormBody);
                    }

                    // Yeni yorum ekleme
                    if (commentAddAjaxModel.CommentDto && commentAddAjaxModel.CommentDto.Comment) {
                        const newSingleComment = `
                            <div class="media mb-4">
                                <img class="d-flex mr-3 rounded-circle" src="https://randomuser.me/api/portraits/men/34.jpg" alt="">
                                <div class="media-body">
                                    <h5 class="mt-0">${commentAddAjaxModel.CommentDto.Comment.CreatedByName}</h5>
                                    ${commentAddAjaxModel.CommentDto.Comment.Text}
                                </div>
                            </div>`;

                        $('#comments').append($(newSingleComment).hide().fadeIn(1000));
                    }

                    toastr.success('Yorum başarıyla eklendi!', 'Başarılı');
                } catch (e) {
                    console.error('Parsing error:', e, 'Raw response:', data);
                    toastr.error('Beklenmeyen bir hata oluştu: ' + e.message, 'Hata');
                }
            },
            error: function (xhr) {
                const errorMessage = xhr.responseJSON?.Message || 'Sunucuyla iletişim kurulamadı';
                toastr.error(errorMessage, 'Hata!');
            }
        });
    });
});
