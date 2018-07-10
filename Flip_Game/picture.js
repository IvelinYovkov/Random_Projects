'use strict'

function Picture(pathASide, pathBSide){
	this.aSide = pathASide;
	this.bSide = pathBSide;
	this.showSide = this.bSide;
}

var picturesDb;
var flipedPair;

function BuildPicture(id){
	var image = document.getElementById(id);
	image.src = picturesDb[id].showSide;
}

function checkForWin(){
	for(var i in picturesDb){
		if(i.showSide === i.bSide)
		{
			return;
		}
	}
	alert('Winner');
}

function flip(id){
	if(picturesDb[id].showSide === picturesDb[id].aSide)
		picturesDb[id].showSide = picturesDb[id].bSide;
	else
		picturesDb[id].showSide = picturesDb[id].aSide;
	
	BuildPicture(id);
}

function flipPicture(id){
	id = id.currentTarget.attributes.id.value;
		flip(id);
		flipedPair.push(id);
	if(flipedPair.length === 2)
		setTimeout(() => checkFlipped(flipedPair[0],flipedPair[1]),500);
		checkForWin();
}

function picturesDbInit(){
	picturesDb = [];
	for(var i = 0; i < 16; i++){
		if(i < 8)
			picturesDb[i] = new Picture('pokemon' + (i + 1) + '.jpg','pokemonBack.jpg');
		else
			picturesDb[i] = new Picture('pokemon' + (i - 7) + '.jpg','pokemonBack.jpg');
	}
}

function checkFlipped(one, two){
	if(picturesDb[one].showSide === picturesDb[two].showSide && one != two){
		var image1 = document.getElementById(one);
		image1.onclick = '';
		var image2 = document.getElementById(two);
		image2.onclick = '';
	}
	else{
		flip(one);
		flip(two);
	}
	flipedPair = [];
}

function fillTable(){
	for(var i = 0; i < 16; i++){
		var image = document.getElementById(i);
		image.onclick = flipPicture;
		BuildPicture(i);
	}
}

function InitTab(){
	picturesDbInit();
	fillTable();
	flipedPair = [];
}