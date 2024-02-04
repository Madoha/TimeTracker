"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();

$(function () {
	connection.start().then(function () {
		alert('Connected to dashboardHub');

		InvokeFinances();

	}).catch(function (err) {
		return console.error(err.toString());
	});
});

// Product
function InvokeFinances() {
	debugger;
	connection.invoke("SendFinances").catch(function (err) {
		return console.error(err.toString());
	});
}

connection.on("ReceivedFinances", function (finances) {
	BindFinancesToGrid(finances);
});

function BindFinancesToGrid(finances) {
	$('#tblFinance tbody').empty();

	var tr;
	$.each(finances, function (index, finances) {
		tr = $('<tr/>');
		tr.append(`<td>${(index + 1)}</td>`);
		tr.append(`<td>${finances.date}</td>`);
		tr.append(`<td>${finances.description}</td>`);
		tr.append(`<td>${finances.amount}</td>`);
		tr.append(`<td>${finances.category}</td>`);
		tr.append(`<td>${finances.transactionType}</td>`);
		tr.append(`<td>${finances.authorId}</td>`);
		$('#tblFinance').append(tr);
	});
}
connection.on("ReceivedFinancesForGraph", function (financesForGraph) {
	BindFinancesToGraph(financesForGraph);
});

function BindFinancesToGraph(financesForGraph) {
	var labels = [];
	var data = [];
	debugger;
	$.each(financesForGraph, function (index, item) {
		labels.push(item.category);
		data.push(item.finances);
	});

	DestroyCanvasIfExists('canvasFinances');

	const context = $('#canvasFinances');
	const myChart = new Chart(context, {
		type: 'doughnut',
		data: {
			labels: labels,
			datasets: [{
				label: '# of Finances',
				data: data,
				backgroundColor: backgroundColors,
				borderColor: borderColors,
				borderWidth: 1
			}]
		},
		options: {
			scales: {
				y: {
					beginAtZero: true
				}
			}
		}
	});
}


connection.on("ReceivedFinancesForGraph", function (financesForGraph) {
	ChartGraph(financesForGraph);
});

function ChartGraph(financesForGraph) {
	var labels = [];
	var data = [];

	$.each(financesForGraph, function (index, item) {
		labels.push(item.category);
		data.push(item.finances);
	});

	DestroyCanvasIfExists('canvasChart');

	const context = $('#canvasChart');
	const myChart = new Chart(context, {
		type: 'line',
		data: {
			labels: labels,
			datasets: [{
				label: '#Chart of Finances',
				data: data,
				backgroundColor: backgroundColors,
				borderColor: borderColors,
				borderWidth: 1
			}]
		},
		options: {
			scales: {
				y: {
					beginAtZero: true
				}
			}
		}
	});
}


connection.on("ReceivedFinancesForGraph", function (financesForGraph) {
	BindCustomersToGraph(financesForGraph);
});

function BindCustomersToGraph(financesForGraph) {
	var datasets = [];
	var labels = ['Finances']
	var data = [];
	$.each(financesForGraph, function (index, item) {
		data = [];
		data.push(item.finances);

		var dataset = {
			label: item.category,
			data: data,
			backgroundColor: backgroundColors[index],
			borderColor: borderColors[index],
			borderWidth: 1
		};

		datasets.push(dataset);
	});

	DestroyCanvasIfExists('canvasBarGraph');

	const context = $('#canvasBarGraph');
	const myChart = new Chart(context, {
		type: 'bar',
		data: {
			labels: labels,
			datasets: datasets,
		},
		options: {
			scales: {
				y: {
					beginAtZero: true
				}
			}
		}
	});
}



// supporting functions for Graphs
function DestroyCanvasIfExists(canvasId) {
	let chartStatus = Chart.getChart(canvasId);
	if (chartStatus != undefined) {
		chartStatus.destroy();
	}
}


var backgroundColors = [
	'rgba(255, 99, 132, 0.2)',
	'rgba(54, 162, 235, 0.2)',
	'rgba(255, 206, 86, 0.2)',
	'rgba(75, 192, 192, 0.2)',
	'rgba(153, 102, 255, 0.2)',
	'rgba(255, 159, 64, 0.2)'
];
var borderColors = [
	'rgba(255, 99, 132, 1)',
	'rgba(54, 162, 235, 1)',
	'rgba(255, 206, 86, 1)',
	'rgba(75, 192, 192, 1)',
	'rgba(153, 102, 255, 1)',
	'rgba(255, 159, 64, 1)'
];