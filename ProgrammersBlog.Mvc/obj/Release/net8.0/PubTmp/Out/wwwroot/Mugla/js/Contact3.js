document.addEventListener('DOMContentLoaded', function () {
    const contactForm = document.getElementById('contactForm');

    const nameInput = document.querySelector('input[name="Name"]');
    const emailInput = document.querySelector('input[name="Email"]');
    const subjectInput = document.querySelector('input[name="Subject"]');
    const messageInput = document.querySelector('textarea[name="Message"]');

    const successAlert = document.getElementById('successAlert');
    const errorAlert = document.getElementById('errorAlert');

    contactForm.addEventListener('submit', function (event) {
        event.preventDefault();
        let isValid = true;

        // İsim kontrolü (Artık nameInput null olmayacak)
        if (nameInput.value.trim() === '') {
            document.getElementById('nameGroup').classList.add('has-error');
            isValid = false;
        } else {
            document.getElementById('nameGroup').classList.remove('has-error');
        }

        // E-posta kontrolü
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(emailInput.value.trim())) {
            document.getElementById('emailGroup').classList.add('has-error');
            isValid = false;
        } else {
            document.getElementById('emailGroup').classList.remove('has-error');
        }

        // Konu kontrolü
        if (subjectInput.value.trim() === '') {
            document.getElementById('subjectGroup').classList.add('has-error');
            isValid = false;
        } else {
            document.getElementById('subjectGroup').classList.remove('has-error');
        }

        // Mesaj kontrolü
        if (messageInput.value.trim() === '') {
            document.getElementById('messageGroup').classList.add('has-error');
            isValid = false;
        } else {
            document.getElementById('messageGroup').classList.remove('has-error');
        }

        if (isValid) {
            // Form gönderimi
            contactForm.submit();
            successAlert.style.display = 'block';
            errorAlert.style.display = 'none';
            setTimeout(() => successAlert.style.display = 'none', 3000);
        } else {
            errorAlert.style.display = 'block';
            setTimeout(() => errorAlert.style.display = 'none', 3000);
        }
    });
});
