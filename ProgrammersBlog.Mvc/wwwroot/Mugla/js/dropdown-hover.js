// Dropdown menüden mouse çıkınca kapanması için JavaScript kodu
document.addEventListener('DOMContentLoaded', function() {
    // Tüm dropdown menüleri seç
    var dropdownMenus = document.querySelectorAll('.dropdown');
    
    // Her dropdown için
    dropdownMenus.forEach(function(dropdown) {
        // Dropdown'dan mouse çıkınca
        dropdown.addEventListener('mouseleave', function() {
            // Dropdown'ı kapat
            var dropdownToggle = dropdown.querySelector('.dropdown-toggle');
            if (dropdownToggle && dropdownToggle.getAttribute('aria-expanded') === 'true') {
                var dropdownInstance = bootstrap.Dropdown.getInstance(dropdownToggle);
                if (dropdownInstance) {
                    dropdownInstance.hide();
                }
            }
        });
    });
});
