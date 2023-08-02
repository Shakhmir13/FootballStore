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
                        <a href="/Admin/Product/Delete?id=${data}"><i class="bi bi-pencil-square">удалить</i></a>
                    `;
                }
            }
        ]
    });
});

