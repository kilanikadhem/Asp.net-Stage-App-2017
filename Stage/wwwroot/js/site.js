var pieChart = function () {
    $('.chart').easyPieChart({
        scaleColor: false,
        lineWidth: 10,
        lineCap: 'butt',
        barColor: '#17e7a4',
        trackColor: "#000000",
        size: 160,
        animate: 1000
    });
    function changeItem(sel) {
        //if (sel.value=="-1" ) return;
        var opt = sel.getElementsByTagName("option");
        console.log(opt);
         };// Write your Javascript code.
