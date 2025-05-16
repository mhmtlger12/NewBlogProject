// Dropdown menülerin sadece tıklama ile çalışması için JavaScript kodu
document.addEventListener('DOMContentLoaded', function() {
    // Tüm dropdown toggle butonlarını seç
    var dropdownToggles = document.querySelectorAll('.mugla-navbar .dropdown-toggle');
    
    // Her dropdown toggle için tıklama olayı ekle
    dropdownToggles.forEach(function(toggle) {
        // Bootstrap dropdown nesnesini oluştur
        var dropdown = new bootstrap.Dropdown(toggle, {
            // Başka bir yere tıklandığında kapat
            autoClose: 'outside'
        });
        
        // Tıklama olayını özelleştir
        toggle.addEventListener('click', function(e) {
            // Varsayılan davranışı engelle
            e.preventDefault();
            e.stopPropagation();
            
            // Diğer tüm dropdown menüleri kapat
            dropdownToggles.forEach(function(otherToggle) {
                if (otherToggle !== toggle) {
                    var otherDropdown = bootstrap.Dropdown.getInstance(otherToggle);
                    if (otherDropdown) {
                        otherDropdown.hide();
                    }
                }
            });
            
            // Bu dropdown'u aç/kapat
            var isOpen = toggle.getAttribute('aria-expanded') === 'true';
            if (isOpen) {
                dropdown.hide();
            } else {
                dropdown.show();
            }
        });
    });
    
    // Dropdown menü içindeki linklere tıklandığında menüyü kapatma
    var dropdownItems = document.querySelectorAll('.mugla-navbar .dropdown-item');
    dropdownItems.forEach(function(item) {
        item.addEventListener('click', function() {
            // Dropdown menüyü kapat (isteyen kullanıcılar için yorum satırına alınabilir)
            // var dropdownMenu = this.closest('.dropdown-menu');
            // if (dropdownMenu) {
            //     var dropdownToggle = dropdownMenu.previousElementSibling;
            //     var dropdown = bootstrap.Dropdown.getInstance(dropdownToggle);
            //     if (dropdown) {
            //         dropdown.hide();
            //     }
            // }
        });
    });
});

