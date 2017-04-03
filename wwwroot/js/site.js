// Write your Javascript code.
$( document ).on("ready", function() {
    //call at bats on inning change
   $("#Number").on("change", updateAB);
   $(".clickable-ab").on("click", updatePitches); 
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
            $('#pitch-vc').load(pitch_url, {"inning_num": inning_num, "top": top, "pitcher_id": pitcher_id, "batter_id": batter_id });
        });
   }

