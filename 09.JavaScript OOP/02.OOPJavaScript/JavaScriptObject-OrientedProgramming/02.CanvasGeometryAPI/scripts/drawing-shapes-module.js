var Drawer = (function () {
    var defaults = {
        lineWidth: 1,
        strokeColor: '#000'
    }

    function Drawer(canvasID) {
        // John Resig Constructor fix - if constructor not used with new
        if (!(this instanceof arguments.callee)) {
            return new Drawer(canvasID);
        }

        var validID = validateID(canvasID);
        if (!validID) {
            throw new Error('The provided ID is not such of a canvas element!');
        }

        this.ctx = document.getElementById(canvasID).getContext('2d');
    }

    function validateID(id) {
        var valid = id && document.getElementById(id) instanceof HTMLCanvasElement;
        return valid;
    }

    Drawer.prototype.rect = function (x, y, width, height, lineWidth, strokeColor, fillColor) {
        this.ctx.beginPath();

        this.ctx.lineWidth = lineWidth || defaults.lineWidth;
        this.ctx.strokeStyle = strokeColor || defaults.strokeColor;

        this.ctx.rect(x, y, width, height);

        if (fillColor) {
            this.ctx.fillStyle = fillColor;
            this.ctx.fill();
        }

        this.ctx.stroke();
    }

    Drawer.prototype.circle = function (x, y, radius, lineWidth, strokeColor, fillColor) {
        this.ctx.beginPath();

        this.ctx.lineWidth = lineWidth || defaults.lineWidth;
        this.ctx.strokeStyle = strokeColor || defaults.strokeColor;

        this.ctx.arc(x, y, radius, 0, 2 * Math.PI);

        if (fillColor) {
            this.ctx.fillStyle = fillColor;
            this.ctx.fill();
        }

        this.ctx.stroke();
    }

    Drawer.prototype.line = function (X1, Y1, X2, Y2, lineWidth, strokeColor) {
        this.ctx.beginPath();

        this.ctx.lineWidth = lineWidth || defaults.lineWidth;
        this.ctx.strokeStyle = strokeColor || defaults.strokeColor;

        this.ctx.moveTo(X1, Y1);
        this.ctx.lineTo(X2, Y2);
        this.ctx.stroke();
    }

    return Drawer;
}())