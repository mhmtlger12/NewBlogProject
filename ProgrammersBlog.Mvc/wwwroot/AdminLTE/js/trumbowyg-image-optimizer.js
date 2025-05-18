/**
 * Trumbowyg Image Optimizer
 * This plugin optimizes images pasted into the Trumbowyg editor
 */
$(document).ready(function () {
    // Bildirim gösterme fonksiyonu
    function showImageProcessingMessage() {
        // Önceki bildirimleri temizle
        $('.image-processing-message').remove();
        
        // Bildirim oluştur ve göster
        var message = $('<div class="alert alert-info image-processing-message" style="position: fixed; top: 10px; right: 10px; z-index: 9999;">' +
                       '<strong>Resim işleniyor!</strong> Büyük resimler otomatik olarak optimize edilecek.' +
                       '</div>');
        
        $('body').append(message);
        
        // 3 saniye sonra bildirimi kaldır
        setTimeout(function() {
            message.fadeOut(function() {
                $(this).remove();
            });
        }, 3000);
    }
    
    // Trumbowyg editörüne resim yapıştırma olayını izle
    $(document).on('paste', '.trumbowyg-editor', function(e) {
        if (e.originalEvent && e.originalEvent.clipboardData) {
            var items = e.originalEvent.clipboardData.items;
            
            for (var i = 0; i < items.length; i++) {
                if (items[i].type.indexOf('image') !== -1) {
                    showImageProcessingMessage();
                    break;
                }
            }
        }
    });
    
    // Text editor'a da event listener ekle
    $('#text-editor').on('paste', function(e) {
        if (e.originalEvent && e.originalEvent.clipboardData) {
            var items = e.originalEvent.clipboardData.items;
            
            for (var i = 0; i < items.length; i++) {
                if (items[i].type.indexOf('image') !== -1) {
                    showImageProcessingMessage();
                    break;
                }
            }
        }
    });
});

// Trumbowyg editörünün pasteImage eklentisini genişlet
$.extend(true, $.trumbowyg, {
    plugins: {
        pasteImage: {
            beforeInsert: function(img) {
                // Resim boyutunu kontrol et ve gerekirse yeniden boyutlandır
                var maxWidth = 800;
                var maxHeight = 600;
                
                if (img.width > maxWidth || img.height > maxHeight) {
                    // Oranı koru
                    var ratio = Math.min(maxWidth / img.width, maxHeight / img.height);
                    img.width = Math.floor(img.width * ratio);
                    img.height = Math.floor(img.height * ratio);
                }
                
                return img;
            }
        }
    }
});
