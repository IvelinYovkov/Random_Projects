'use strict'

var now = new Date();

alert(now.getTime());

function Human(fname,lname, gender)
{
	this.fullName = fname + ' ' + lname;
	this.lname = lname;
	this.fname = fname;
	this.gender = gender;
}

Human.prototype.tellName = function()
{
	display(this.fullName);
}

function Worker(salary, fname, lname, gender){
	Human.call(this,fname,lname,gender)
	this.salary = salary
}

Worker.prototype = Object.create(Human.prototype)

var tsani = new Worker(100, 'Ts', 'G','male')

alert(tsani.fullName + tsani.salary + tsani.gender)

