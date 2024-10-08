(function($) {
	"use strict";

	/* Chartjs (#revenue) */
	var myCanvas = document.getElementById("budget");
	myCanvas.height="285";
	var myCanvasContext = myCanvas.getContext("2d");
	var gradientStroke1 = myCanvasContext.createLinearGradient(0, 0, 0, 380);
	gradientStroke1.addColorStop(0, '#42a8ab');
	gradientStroke1.addColorStop(1, '#42a8ab');

	var gradientStroke2 = myCanvasContext.createLinearGradient(0, 0, 0, 300);
	gradientStroke2.addColorStop(0, '#8c8eef');
	gradientStroke2.addColorStop(1, '#8c8eef');

	var myChart = new Chart(myCanvas, {
		type: 'bar',
		data: {
			labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "July", "Aug", "Sep", "Oct", "Nov", "Dec"],
			datasets: [{
				label: 'Total Budget',
				data: [15, 18, 12, 14, 10, 15, 7, 14, 10, 15, 7, 14],
							backgroundColor: gradientStroke1,
							hoverBackgroundColor: gradientStroke1,
							hoverBorderWidth: 2,
							hoverBorderColor: 'gradientStroke1'
			}, {

			    label: 'Total amount',
				data: [10, 14, 10, 15, 9, 14, 15, 20, 10, 15, 7, 14],
							backgroundColor: gradientStroke2,
							hoverBackgroundColor: gradientStroke2,
							hoverBorderWidth: 2,
							hoverBorderColor: 'gradientStroke2'

			}
		  ]
		},
		options: {
			responsive: true,
			maintainAspectRatio: false,
			tooltips: {
				mode: 'index',
				titleFontSize: 12,
				titleFontColor: '#8e9cad',
				bodyFontColor: '#8e9cad',
				backgroundColor: '#fff',
				cornerRadius: 3,
				intersect: false,
			},
			legend: {
				display: false,
				labels: {
					usePointStyle: true,
					fontFamily: 'Montserrat',
				},
			},
			scales: {
				xAxes: [{
					barPercentage:0.5,
					ticks: {
						fontColor: "#8e9cad",

					 },
					display: true,
					gridLines: {
						display: true,
						color: 'rgba(142, 156, 173,0.2)',
						drawBorder: false
					},
					scaleLabel: {
						display: false,
						labelString: 'Month',
						fontColor: '#8e9cad'
					}
				}],
				yAxes: [{
					ticks: {
						fontColor: "#8e9cad",
					 },
					display: true,
					gridLines: {
						display: true,
						color: 'rgba(142, 156, 173,0.2)',
						drawBorder: false
					},
					scaleLabel: {
						display: false,
						labelString: 'sales',
						fontColor: '#8e9cad'
					}
				}]
			},
			title: {
				display: false,
				text: 'Normal Legend'
			}
		}
	});
	/* Chartjs (#revenue) closed */


	/* sparkline_bar1 */
	$(".sparkline_bar1").sparkline([2, 4, 3, 4, 5, 4,5,3,4,5,2,4,5,4,3,5,4,3,4,5,4,3,5,4,3,4,5], {
		type: 'bar',
		height: 40,
		width:250,
		barWidth: 5,
		barSpacing: 7,
		colorMap: {
			'9': '#a1a1a1'
		},
		barColor: '#8c8eef'
	});
	/* sparkline_bar1 end */

	/* sparkline_bar1 */
	$(".sparkline_bar2").sparkline([3, 5, 4, 4, 5, 4,5,3,4,5,3,4,5,4,3,5,4,3,4,5,4,3,5,4,3,4,5], {
		type: 'bar',
		height: 40,
		width:250,
		barWidth: 5,
		barSpacing: 7,
		colorMap: {
			'9': '#a1a1a1'
		},
		barColor: '#90c7ec'
	});
	/* sparkline_bar1 end */

})(jQuery);
