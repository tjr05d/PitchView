// Write your Javascript code.
$( document ).ready(function() {
    $("#Number").change(function() {

        var inning_selected = $("#Number").find(":selected").val();
    
        var inning_num = inning_selected.split(",")[0]; 
        var top = inning_selected.split(",")[1]; 

        $.ajax(
        {
            url: "/Inning/GetAtBats", 
            data: {"inning_num": inning_num, "top": top },
            success: function(response) {
                $('#ab-vc').html(response); 
            }, 
             error: function(xhr) { console.log(xhr)}
        }
        );

   }) 
});

