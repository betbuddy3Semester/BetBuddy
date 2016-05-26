

$("#AlleKampeID form")
    .submit(function() {

        var buttomClass = $("form input[type=submit][clicked=true]");
        console.log(buttomClass);
        buttomClass = buttomClass.context.activeElement.name;
        console.log(buttomClass);
        if (buttomClass == "Odds1") {
            $(this).attr("action", "/Kupon/PostOdds1");
        } else if (buttomClass == "OddsX") {
            $(this).attr("action", "/Kupon/PostOddsX");
        } else {
            $(this).attr("action", "/Kupon/PostOdds2");
        }

    });

var samletOdds = 1;
$(".OddsBox")
    .each(function() {
        var fixtTal = $(this).text().replace(",", ".");
        samletOdds *= fixtTal;
    });
samletOdds = Math.round(samletOdds * 100) / 100;
if (samletOdds != 1) {
    $("#oddsResult").text(samletOdds);
} else {
    $(".OddsBoxStart").hide();
}
var dinePoing = parseInt($("#dinePoing").text());
var bettingPoint = $("input[name=bettingPoint]");
bettingPoint.keyup(function() {


    var point = bettingPoint.val() * samletOdds;
    point = Math.round(point * 100) / 100;
    $("#dinePoing").text(dinePoing - bettingPoint.val());
    $("#gevinst").text(point);
});

var kupon = function() {
    this.kamp = [];
    this.addKamp = function(kamp) {
        this.kamp.push(kamp);
    };
};
$("#ajaxUsername").keyup(function() {
    var text = $(this).val();
    $.getJSON("http://localhost:50617/bruger/GetApi", { text: text }, function(json) {
        $("#AjaxReturnValue").text(json.text);
        if (json.status == "1") {
            $("#ajaxUsername").attr("style", "border:1px solid red");
        } else if(json.stuts == "2") {
            $("#ajaxUsername").attr("style", "border:1px solid yellow");
        } else {
            $("#ajaxUsername").attr("style", "border:1px solid green");
        }
    });
});