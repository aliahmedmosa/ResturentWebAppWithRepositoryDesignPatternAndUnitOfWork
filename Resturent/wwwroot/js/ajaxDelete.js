//@foreach(var item in Model)
//{
//    <tr class="Item-row">
//        <th>
//            <a href="javascript:;" class="btn btn-danger js-delete" data-id="@item.Id">Delete</a>
//        </th>
//    </tr>
//}
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