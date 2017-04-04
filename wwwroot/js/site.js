// Write your Javascript code.
$( document ).on("ready", function() {
    $('select').material_select();
    pitcherChart();
    //call at bats on inning change
    $("#Number").on("change", updateAB);
    $(".clickable-ab").each( function() {
       var $this = $(this); 
       $this.on("click", function() {
           updatePitches($this);
           $this.addClass("ab-active");
       })
   })
});

function updateAB() {

        var inning_selected = $("#Number").find(":selected").val();
        var inning_num = inning_selected.split(",")[0]; 
        var top = inning_selected.split(",")[1]; 

        var ab_url = "/Inning/GetAtBats"
        var ab_data = {"inning_num": inning_num, "top": top}

        $('#ab-vc').load(ab_url, ab_data, function(){

            var inning_selected = $("#Number").find(":selected").val();
            var inning_num = inning_selected.split(",")[0]; 
            var top = inning_selected.split(",")[1]; 

            var pitcher_id = $(".clickable-ab").data("pitcher");
            var batter_id = $(".clickable-ab").data("batter");
            var pitch_url = "/Inning/GetPitches"
            var pitch_data = {"inning_num": inning_num, "top": top, "pitcher_id": pitcher_id, "batter_id": batter_id }; 
            $('#pitch-vc').load(pitch_url, pitch_data, function(){
                console.log("rebinding handler");
                $(".clickable-ab").each( function() {
                    var $this = $(this); 
                    $this.on("click", function() {
                        updatePitches(this);
                        $this.addClass("ab-active");
                    })
                })
            });
        });
   }

function updatePitches(element) {
    $(".clickable-ab").removeClass("ab-active"); 

    var inning_selected = $("#Number").find(":selected").val();
    var inning_num = inning_selected.split(",")[0]; 
    var top = inning_selected.split(",")[1]; 

    var pitcher_id = $(element).data("pitcher");
    var batter_id = $(element).data("batter");
    var pitch_url = "/Inning/GetPitches" 
    
    var data = {"inning_num": inning_num, "top": top, "pitcher_id": pitcher_id, "batter_id": batter_id }; 
    $('#pitch-vc').load(pitch_url, data, function() {
        console.log("rebinding handler");
                $(".clickable-ab").each( function() {
                    var $this = $(this); 
                    $this.on("click", function() {
                        updatePitches(this);
                        $this.addClass("ab-active");
                    })
                })
    });
}

function pitcherChart(){
     var myChart = Highcharts.chart('container', {
        chart: {
            type: 'line'
        },
        title: {
            text: 'Average Fastball Velocity'
        },
        xAxis: {
            title: {text: "Inning"}, 
            categories: [1,2,3,4]
        },
        yAxis: {
            title: {
                text: 'Avg. Speed'
            }
        },
        series: [{
            name: 'Feirs, Mike', 
            data: [88.6, 86.7, 87.6]
        }]
    });
}