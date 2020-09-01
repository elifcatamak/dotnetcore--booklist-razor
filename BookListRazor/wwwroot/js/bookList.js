var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    // .DataTable populates a data table on DT_load
    dataTable = $('#DT_load').DataTable({
        // Ajax call to our api
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        // Defining columns that we display
        // Have to be camel case
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                // When we edit or delete, we need to pass the id of the book
                "data": "id",
                // We want to render two buttons here, function returns a div with two buttons
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/BookList/Edit?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:70px">
                            Edit
                        </a>
                        &nbsp;
                        <a class="btn btn-danger text-white" style="cursor:pointer; width:70px">
                            Delete
                        </a>
                    </div>`;
                },
                "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}