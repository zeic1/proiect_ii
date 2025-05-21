// Optional example: Validate form inputs before submitting
document.querySelectorAll('.auth-form form').forEach(form => {
    form.addEventListener('submit', function (e) {
        const inputs = form.querySelectorAll('input');
        let valid = true;

        inputs.forEach(input => {
            if (!input.value) {
                valid = false;
                input.style.borderColor = 'red';
            } else {
                input.style.borderColor = '#ccc';
            }
        });

        if (!valid) {
            e.preventDefault();
            alert('Please fill in all fields.');
        }
    });
});
