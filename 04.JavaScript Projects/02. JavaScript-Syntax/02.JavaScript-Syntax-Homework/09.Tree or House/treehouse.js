function treeHouseCompare(a, b) {
    var houseArea = a * a + (a * (a * 2 / 3)) / 2;
    var treeArea = b * (b / 3) + Math.PI * (b * 2 / 3) * (b * 2 / 3);
    if (treeArea > houseArea) {
        console.log("tree/" + treeArea.toFixed(2));
    } else {
        console.log("house/" + houseArea.toFixed(2));
    }
}


treeHouseCompare(3, 2);
treeHouseCompare(3, 3);
treeHouseCompare(4, 5);