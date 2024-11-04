// Custom JavaScript can be added here
document.addEventListener("DOMContentLoaded", function () {
    // Example: Show a confirmation dialog on delete actions
    const deleteButtons = document.querySelectorAll('.btn-danger');

    deleteButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            const confirmation = confirm('Are you sure you want to delete this item?');
            if (!confirmation) {
                event.preventDefault();
            }
        });
    });
});
