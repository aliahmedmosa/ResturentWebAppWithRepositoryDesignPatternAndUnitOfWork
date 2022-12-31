$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);

        var result = confirm('are you sure you want to delete this item ?')
        if (result) {
            $.ajax({
                url: '/Category/Delete/' + btn.data('id'),
                success: function () {
                    btn.parents('.Item-row').fadeOut();
                    toastr.success("Category deleted !")
                },
                error: function () {
                    toastr.error("Something went rong !")
                }
            });
        }
    });
});