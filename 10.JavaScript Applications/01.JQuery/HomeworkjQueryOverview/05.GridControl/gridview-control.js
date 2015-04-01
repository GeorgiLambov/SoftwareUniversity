var gridViewControls = (function () {
    var currentRow = 0;

    var GridView = (function () {
        function GridView(containerSelector) {
            this._container = $(containerSelector);
            this.header = null;
            this.rows = [];
        }

        GridView.prototype.addRow = function () {
            var newRow = new GridViewRow(arguments);
            this.rows.push(newRow);
            return newRow;
        };

        GridView.prototype.addHeader = function () {
            if (this.header) {
                throw new Error("GridViews cannot have more than one header!");
            }

            var header = new GridViewHeader(arguments);
            this.header = header;
        };

        GridView.prototype.render = function () {
            this._container.append(this.getRendered);
        };
        function getRendered() {
            var table, tbody, i, rowsCount, currentRow;
            table = $("<table>");
            if (this.header) {
                table.append(this.header.getRendered());
            }

            tbody = $("<tbody>");
            rowsCount = this.rows.length;
            for (i = 0; i < rowsCount; i++) {
                currentRow = this.rows[i];
                tbody.append(currentRow.getRendered());

                if (currentRow.nestedGridView) {
                    tbody.append($("<tr></tr>")
                         .addClass("nested")
                         .append($("<td></td>")
                         .attr("colspan", currentRow.columnsContents.length)
                         .append(currentRow.nestedGridView._getRendered()))
                         .hide());
                }
            }

            table.append(tbody);
            return table;
        }

        return GridView;
    }());

    var GridViewRow = (function () {
        function GridViewRow(columnsContents) {
            this.columnsContents = columnsContents;
            this.nestedGridView = null;
        };

        GridViewRow.prototype.getNestedGridView = function () {
            var nestedGridView = new GridView("#row" + currentRow++);
            this.nestedGridView = nestedGridView;
            return nestedGridView;
        };

        GridViewRow.prototype.getRendered = function () {
            var row, i, columnsCount;
            row = $("<tr>");
            row.attr("id", ("row" + currentRow));

            columnsCount = this.columnsContents.length
            for (i = 0; i < columnsCount; i++) {
                row.append("<td>" + this.columnsContents[i] + "</td>");
            };

            row.click(handleRowClick);

            return row;
        }

        return GridViewRow
    }());

    var GridViewHeader = (function () {
        function GridViewHeader(columnsContents) {
            (columnsContents);
        };
        GridViewHeader.prototype.getRendered = function () {
            var header, headerRow, innerHtml, i, columnsCount;
            header = $("<thead></thead>");
            headerRow = $("<tr></tr>");
            innerHtml = "";

            columnsCount = this.columnsContents.length;
            for (i = 0; i < columnsCount; i++) {
                innerHtml += "<th>" + this.columnsContents[i] + "</th>";
            }

            headerRow.append(innerHtml);
            headerRow.appendTo(header);
            return header;
        }

        return GridViewHeader;
    }());

    function handleRowClick(event) {
        if ($(this).next().hasClass("nested")) {
            $(this).next().toggle();
        }
    }

    return {
        getGridView: function (containerSelector) {
            return new GridView(containerSelector);
        }
    }
})();