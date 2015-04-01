Object.prototype.extends = function (parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

var Point = (function () {
    function Point(x, y) {
        this.setX(x);
        this.setY(y);
    }
    
    Point.prototype.setX = function (x) {
        this._x = x;
    };
    
    Point.prototype.setY = function (y) {
        this._y = y;
    };
    
    Point.prototype.getX = function () {
        return this._x;
    };
    
    Point.prototype.getY = function () {
        return this._y;
    };
    
    Point.prototype.toString = function () {
        return this.constructor.name + ': ' + "X: " + this._x + ", Y: " + this._y;
    };
    
    return Point;
})();


var Shape = (function () {
    function Shape(point, color) {
        if (this.constructor === Shape) {
            throw new Error("Can't instantiate abstract class Shape.");
        }
        
        this._point = point;
        this._color = color;
    }
    
    Shape.prototype = {
        toString: function () {
            return "Color in hexadecimal format: " + this._color;
          
        },
        canvas: function () {
            var canvas = {
                element: document.getElementById("shapesConteiner").getContext("2d")
            };
            
            return canvas;
        }
    };
    
    return Shape;
})();


var Circle = (function () {
    
    function Circle(point, color, radius) {
        Shape.call(this, point, color);
        this.setRadius(radius);
    }
    //  All extension methods should be declared after the "Child.extends(Parent)" statement or Child.prototype = new Parent();
    Circle.extends(Shape);
    
    Circle.prototype.setRadius = function (radius) {
        this._radius = radius;
    };
    Circle.prototype.getRadius = function () {
        return this._radius;
    };
    
    Circle.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.arc(this._point.getX(), this._point.getY(), this._radius, 0, 2 * Math.PI, false);
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.fill();
        this.canvas().element.stroke();
    };
    
    Circle.prototype.toString = function () {
        return this.constructor.name + "\n" + Shape.prototype.toString.call(this) +
            "\nRadius: " + this.getRadius() 
            + "\n" + this._point;
    };
    
    return Circle;
}());


var Rectangle = (function () {
    
    function Rectangle(point, color, width, height) {
        Shape.call(this, point, color);
        this._width = width;
        this._height = height;
    }
    
    Rectangle.extends(Shape);
    
    Rectangle.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.fillRect(this._point.getX(), this._point.getY(), this._width, this._height);
    };
    
    Rectangle.prototype.toString = function () {
        return this.constructor.name + "\n" + Shape.prototype.toString.call(this) +
            "\nWidth:" + this._width +
            "\nHeight:" + this._height +
            "\n" + this._point;
    };
    
    return Rectangle;
}());


var Triangle = (function () {
    
    function Triangle(point, color, point2, point3) {
        Shape.call(this, point, color);
        this._point2 = point2;
        this._point3 = point3;
    }
    
    Triangle.extends(Shape);
    
    Triangle.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.moveTo(this._point._x, this._point._y);
        this.canvas().element.lineTo(this._point2._x + this._point._x, this._point2._y + this._point._y);
        this.canvas().element.lineTo(this._point3._x + this._point._x, this._point3._y + this._point._y);
        this.canvas().element.fill();
    };
    
    Triangle.prototype.toString = function () {
        return this.constructor.name + "\n" + Shape.prototype.toString.call(this) + 
        "\n" + this._point +
        "\n" + this._point2 + 
        "\n" + this._point3;
    };
    
    return Triangle;
}());

var Segment = (function () {
    
    function Segment(point, color, point2) {
        Shape.call(this, point, color);
        this._point2 = point2;
    }
    
    Segment.extends(Shape);
    
    Segment.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.moveTo(this._point._x, this._point._y);
        this.canvas().element.lineTo(this._point2._x + this._point._x, this._point2._y + this._point._y);
        this.canvas().element.stroke();
    };
    
    Segment.prototype.toString = function () {
        return this.constructor.name + "\n" + Shape.prototype.toString.call(this) +
                               "\n" + this._point +
                               "\n" + this._point2;
    };
    
    return Segment;
}());


// Test in Node.js
//var shape = new Shape(10, 20, "#101310");  // throw Eror

var point = new Point(100, 200);
var circle = new Circle(point, "#2D20AA", 50);
console.log(circle.toString());

//var point = new Point(180, 300);
//var rectangle = new Rectangle(point, "#AA1111", 150, 200);
//console.log(rectangle.toString());


//var point = new Point(50, 50);
//var point1 = new Point(80, 80);
//var point2 = new Point(90, 25);
//var triangle = new Triangle(point, "#9900FF", point1, point2);
//console.log(triangle.toString());


//var point = new Point(150, 120);
//var point1 = new Point(100, 100);
//var segment = new Segment(point, "#001", point1);
//console.log(segment.toString());
