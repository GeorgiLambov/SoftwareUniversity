function onLogoClicked() {
	console.log(this);
	alert("You clicked the SoftUni Logo!");
}

function onGenderChange(e) {
	var select = document.getElementById("gender-select");
	alert(select.options[select.selectedIndex].value)
}