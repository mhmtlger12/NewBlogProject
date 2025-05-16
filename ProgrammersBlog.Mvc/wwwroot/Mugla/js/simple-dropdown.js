// Çok basit dropdown menü işlevselliği
document.addEventListener('DOMContentLoaded', function() {
    // Bootstrap'in dropdown işlevselliğini kullan
    var dropdownElementList = document.querySelectorAll('.dropdown-toggle');
    
    // Her dropdown için
    dropdownElementList.forEach(function(el) {
        // Hover olayını devre dışı bırak
        el.parentElement.addEventListener('mouseenter', function(e) {
            // Hover ile hiçbir şey yapma
        });
        
        // Sadece tıklama ile çalışsın
        el.addEventListener('click', function(e) {
            // Diğer açık dropdown'ları kapat
            dropdownElementList.forEach(function(otherEl) {
                if (otherEl !== el && otherEl.getAttribute('aria-expanded') === 'true') {
                    var dropdown = bootstrap.Dropdown.getInstance(otherEl);
                    if (dropdown) {
                        dropdown.hide();
                    }
                }
            });
        });
    });
});
