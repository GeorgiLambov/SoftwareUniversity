function calcCylinderVol(radius, height) {
    var pi = Math.PI;
    var volume = pi * Math.pow(radius, 2) * height;
    console.log(volume.toFixed(3));
}

calcCylinderVol(2, 4);
calcCylinderVol(5, 8);
calcCylinderVol(12, 3);