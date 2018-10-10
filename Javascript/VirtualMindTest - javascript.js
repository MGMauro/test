1)
function Employee(first, last, salary) {
    this.firstName = first;
    this.lastName = last;
    this.salary = salary;
    
}
Employee.prototype.increasSalary = function() {
    return this.salary + 1000
};

Employee.prototype.details = function() {
    return 'Name: '+this.firstName + ' '+ this.lastName +', Salary: '+ this.salary;
};

2)
function MultiplyBy(a,b,c){
return a*b*c;
};

3)
function LongestCountryName(countries){
	return longest = countries.sort(function (a, b) { return b.length - a.length; })[0];
};

4)
function removecolor()
{
var x=document.getElementById("colorSelect");
x.remove(x.selectedIndex);
}

5)
function insert_Row()
{
var x=document.getElementById('sampleTable').insertRow(0);
}