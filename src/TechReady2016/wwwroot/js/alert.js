var HelloWorld = (function () {
    function HelloWorld() {
    }
    HelloWorld.prototype.SayHello = function () {
        alert("Hello World");
    };
    return HelloWorld;
}());
var x = new HelloWorld();
x.SayHello();
