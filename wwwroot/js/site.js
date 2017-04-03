// Write your Javascript code.
$( document ).on("ready", function() {
    //call at bats on inning change
   $("#Number").on("change", updateAB);
   $(".clickable-ab").each( function() {
       var $this = $(this); 
       $this.on("click", function() {
           updatePitches(this);
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
                    })
                })
            });
        });
   }

function updatePitches(element) {
    var inning_selected = $("#Number").find(":selected").val();
    var inning_num = inning_selected.split(",")[0]; 
    var top = inning_selected.split(",")[1]; 

    var pitcher_id = $(element).data("pitcher");
    var batter_id = $(element).data("batter");
    var pitch_url = "/Inning/GetPitches" 
    
    var data = {"inning_num": inning_num, "top": top, "pitcher_id": pitcher_id, "batter_id": batter_id }; 
    $('#pitch-vc').load(pitch_url, data, function() {
        console.log("I ran too"); 
    });
}
