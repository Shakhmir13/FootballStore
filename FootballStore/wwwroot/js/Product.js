var dtable;
$(document).ready(function () {
    dtable = $('#myTable').DataTable({
        "ajax": { "url": "/Admin/Product/AllProducts" },
        "columns": [
            { "data": "name" },
            { "data": "description" },
            { "data": "price" },
            { "data": "category.name" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <a href="/Admin/Product/CreateUpdate?id=${data}"><i class="bi bi-pencil-square">изменить</i></a>
                        <a onclick="RemoveProduct('/Admin/Product/Delete/${data}')"><i class="bi bi-trash">удалить</i></a>
                    `;
                }
            }
        ]
    });
});

function RemoveProduct(url) {
    Swal.fire({
        title: 'Удалить?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Да'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE', // Здесь у вас была пропущена запятая
                success: function (data) {
                    if (data.success) {
                        dtable.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                },
                error: function (xhr, status, error) {
                    toastr.error("Произошла ошибка при удалении товара.");
                }
            });
        }
    });
}
