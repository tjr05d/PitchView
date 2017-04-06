// Write your Javascript code.
$( document ).on("ready", function() {
    $('select').material_select();
    // updatePitcherChart();
    //start madness
    $(document).on("click", ".pitch", {}, function(e){
        var $this = $(this);
        updatePitcherStats($this);
    })
    //stop madness
    //call at bats on inning change
    $("#Number").on("change", updateAB);
    //handlers for the atbat ajax call
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
        $(".clickable-ab").removeClass("ab-active");

        $('#ab-vc').load(ab_url, ab_data, function(){

            var inning_selected = $("#Number").find(":selected").val();
            var inning_num = inning_selected.split(",")[0]; 
            var top = inning_selected.split(",")[1]; 

            var pitcher_id = $(".clickable-ab").data("pitcher");
            var batter_id = $(".clickable-ab").data("batter");
            var pitch_url = "/Inning/GetPitches"
            var pitch_data = {"inning_num": inning_num, "top": top, "pitcher_id": pitcher_id, "batter_id": batter_id }; 
            $('#pitch-vc').load(pitch_url, pitch_data, function(){
                $(".clickable-ab").first( function(){
                    var $this = $(this); 
                    $this.addClass("ab-active"); 
                })
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

function updatePitcherChart(pitcher, innings, avgSpeeds, type){
    var myChart = Highcharts.chart('velocity-graph', {
        chart: {
            type: type
        },
        title: {
            text: 'Average Fastball Velocity'
        },
        xAxis: {
            title: {text: "Inning"}, 
            categories: innings
        },
        yAxis: {
            title: {
                text: 'Avg. Speed'
            }
        },
         plotOptions: {
        line: {
            dataLabels: {
                enabled: false
            },
                enableMouseTracking: true
            }
        }, 
        series: [{
            name: pitcher, 
            data: avgSpeeds
        }]
    });
    $(".highcharts-credits").hide();
}

function updatePitcherStats(element){
    //handlers for the pitcher stats ajax call
    var gamePitchNumber = element.data("pitchnum"); 
    var pitcherId = element.data("id");  
    var pitcherName = element.data("name").replace(",", " ");

    var pitcherStatsUrl = "/Inning/PitcherStats"
    var data = {"game_pitch_number": gamePitchNumber,  "pitcher_id": pitcherId, "pitcher_name": pitcherName }

    $.get(pitcherStatsUrl, data, function(response){
        var innings = Object.keys(response);
        var avgSpeeds =  innings.map(function (k) {
            return response[k];
        }); 
        //changes graph to bar if there is only data for one innintg
        var type = innings.length <= 1 ? 'column' : 'line'
        updatePitcherChart(pitcherName, innings, avgSpeeds, type); 
    })
}