
$(document).ready(function () {
    $(".sortable").click(function () {
        var column = $(this).data("column");
        var sortOrder = $(this).hasClass("asc") ? "desc" : "asc";

        // Elimina la clase de ordenamiento de otras columnas
        $(".sortable").removeClass("asc desc");

        // Agrega la clase de ordenamiento a la columna actual
        $(this).addClass(sortOrder);

        // Ordena la tabla
        sortTable(column, sortOrder);
    });
});

function sortTable(column, sortOrder) {
    var tbody = $("table tbody");
    var rows = tbody.find("tr").get();

    rows.sort(function (a, b) {
        var aValue = $(a).find("td:eq(" + $(a).find("th[data-column='" + column + "']").index() + ")").text();
        var bValue = $(b).find("td:eq(" + $(b).find("th[data-column='" + column + "']").index() + ")").text();

        if ($.isNumeric(aValue) && $.isNumeric(bValue)) {
            aValue = parseFloat(aValue);
            bValue = parseFloat(bValue);
        }

        if (sortOrder === "asc") {
            return aValue > bValue ? 1 : -1;
        } else {
            return aValue < bValue ? 1 : -1;
        }
    });

    $.each(rows, function (index, row) {
        tbody.append(row);
    });
}