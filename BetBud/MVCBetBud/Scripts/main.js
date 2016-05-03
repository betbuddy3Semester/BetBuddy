

$("#AlleKampeID form").submit(function() {
    
    var buttomClass = $("form input[type=submit][clicked=true]");
    console.log(buttomClass);
    buttomClass = buttomClass.context.activeElement.name;
    console.log(buttomClass);
    if (buttomClass == "Odds1") {
        $(this).attr("action", "/Kupon/PostOdds1");
    }else if (buttomClass == "OddsX") {
        $(this).attr("action", "/Kupon/PostOddsX");
    } else {
        $(this).attr("action", "/Kupon/PostOdds2");
    }
    
});
