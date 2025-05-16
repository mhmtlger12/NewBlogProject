$(document).ready(function () {
    toastr.options = {
        "closeButton": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "timeOut": 5000
    };

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
