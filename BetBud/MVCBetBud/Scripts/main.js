/*$("#AlleKampeID").on("click", "input", function () {
    var theForm = $("#AlleKampeID form");
    theForm.preventDefault();
    console.log("fisk");
    theForm.attr("action", "/KuponController/Odds1");
    //theForm.submit();
});*/
$("#AlleKampeID form").submit(function() {
    
    var buttomClass = $("form input[type=submit][clicked=true]");
    console.log(buttomClass);
    buttomClass = buttomClass.context.activeElement.name;
    console.log(buttomClass);
    if (buttomClass == "Odds1") {
        $(this).attr("action", "/KuponController/PostOdds1");
    }else if (buttomClass == "OddsX") {
        $(this).attr("action", "/KuponController/PostOddsX");
    } else {
        $(this).attr("action", "/KuponController/PostOdds2");
    }
    
});
/*
$(".Odds1").click(function () {
    var theForm = $(".kampForm");
    theForm.preventDefault();
    theForm.attr("action", "@Url.Action("Odds1", "KuponController")");
    theForm.submit();
});
$(".OddsX").click(function () {
    var theForm = $(".kampForm");
    theForm.preventDefault();
    theForm.attr("action", "@Url.Action("OddsX", "KuponController")");
    theForm.submit();
});
$(".Odds2").click(function () {
    var theForm = $(".kampForm");
    theForm.preventDefault();
    theForm.attr("action", "@Url.Action("Odds2", "KuponController")");
    theForm.submit();
});*/