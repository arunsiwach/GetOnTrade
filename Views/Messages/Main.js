function News(tag) {
    //debugger;
    showTweets = true;
    showNews = true;
    peopleinfo = "";
    people = "";
    people = JSON.parse(data);
    //debugger;
    //readTextFile("https://getontrades.azurewebsites.net/File", function (text) {
    //    debugger;
    //    people = JSON.parse(text);
    //});

    selectedTradinghours = tradinghours();
    /*alert(selectedTradinghours);*/
    selectedPlatform = TradingPlatform();
    selectedShortCut = GetShortCut();

    var isRecent = (selectedShortCut == "Recent");


    var options = document.getElementsByName("colors");
    var optionsPercent = document.getElementsByName("percent");

    var selectedPercent = '';
    var selected = '';

    if (optionsPercent) {
        for (var i = 0; i < optionsPercent.length; i++) {
            if (optionsPercent[i].checked) {
                selectedPercent = optionsPercent[i].value;
            }
        }
    }

    if (selectedPercent == '0TO5') {
        minPercent = 0;
        maxPercent = 5;
    }
    else if (selectedPercent == '5TO10') {
        minPercent = 5;
        maxPercent = 10;
    }
    else if (selectedPercent == '10TO20') {
        minPercent = 10;
        maxPercent = 20;
    }
    else if (selectedPercent == '20TO40') {
        minPercent = 20;
        maxPercent = 40;
    }
    else if (selectedPercent == '40TO100') {
        minPercent = 40;
        maxPercent = 100;
    }
    else if (selectedPercent == '100Above') {
        minPercent = 100;

    }
    else {
        minPercent = -100;
        maxPercent = 100000;
    }

    if (options) {
        for (var i = 0; i < options.length; i++) {
            if (options[i].checked) {

                selected = options[i].value;
            }
        }
    }
    //  var selectedTodayYesterday = false;

    if (selected == 'today') {
        selectedToday = true;
        selectedTodayYesterday = false;
    }
    else if (selected == 'todayYesterday') {
        selectedToday = false;
        selectedTodayYesterday = true;
    }
    else {
        selectedToday = false;
        selectedTodayYesterday = false;
    }

    if (tag != "RecentChange" && !isRecent) {

        //if (selectedTradinghours == 'Trading') {
        //    FlipSortIn();
        //}
        //else if (selectedTradinghours == 'After') {
        //    FlipSortAfter();
        //}

        //else {
        //    FlipSortPre();
        //}
        FlipSort();
    }
    else if ((tag == "RecentChange") || isRecent) {
        FlipSortRecent();
    }
    else {
        FlipSortVolume();
    }

    //if (selectedShortCut == 'Recent') {
    //    FlipSortRecent();
    //}
    //else if (selectedShortCut == 'Volume') {
    //    FlipSortVolume();
    //}

    var optionsTime = document.getElementsByName("time");
    if (optionsTime) {
        for (var i = 0; i < optionsTime.length; i++) {
            if (optionsTime[i].checked) {
                if (optionsTime[i].value == 'hour') {
                    selectedTimeHour = true;
                }
                else {
                    selectedTimeHour = false;
                }
            }
        }
    }

    var optionsTweet = document.getElementsByName("tweet");
    if (optionsTweet) {
        for (var i = 0; i < optionsTweet.length; i++) {
            if (optionsTweet[i].checked) {
                if (optionsTweet[i].value == 'tweet') {
                    selectedTweeted = true;
                }
                else {
                    selectedTweeted = false;
                }
            }
        }
    }

    var optionsNew = document.getElementsByName("new");
    if (optionsNew) {
        for (var i = 0; i < optionsNew.length; i++) {
            if (optionsNew[i].checked) {
                if (optionsNew[i].value == 'new') {
                    selectedNew = true;
                }
                else {
                    selectedNew = false;
                }
            }
        }
    }

    var optionsfloat = document.getElementsByName("float");
    if (optionsfloat) {
        for (var i = 0; i < optionsfloat.length; i++) {
            if (optionsfloat[i].checked) {
                if (optionsfloat[i].value == 'float') {
                    selectedLowFloat = true;
                }
                else {
                    selectedLowFloat = false;
                }
            }
        }
    }

    var optionsRecomended = document.getElementsByName("recom");
    if (optionsfloat) {
        for (var i = 0; i < optionsRecomended.length; i++) {
            if (optionsRecomended[i].checked) {
                if (optionsRecomended[i].value == 'Recomended') {
                    selectedRecomended = true;
                }
                else {
                    selectedRecomended = false;
                }
            }
        }
    }

    var optionsBio = document.getElementsByName("Bio");
    if (optionsfloat) {
        for (var i = 0; i < optionsBio.length; i++) {
            if (optionsBio[i].checked) {
                if (optionsBio[i].value == 'NoBio') {
                    selectedBio = true;
                }
                else {
                    selectedBio = false;
                }
            }
        }
    }



    var optionsPrice = document.getElementsByName("price");
    if (optionsPrice) {
        for (var i = 0; i < optionsPrice.length; i++) {
            if (optionsPrice[i].checked) {
                selectedPrice = optionsPrice[i].value;
            }
        }
    }

    if (tag == "SeekingAlpha") {
        // FlipSort();
        for (i = 0; i < people.length; i++) {
            if (people[i].NewsLink.includes("seekingalpha")) {
                peopleinfo += GetPeopleInfo(people[i]);
            }
        }
        document.getElementById("demo").innerHTML = peopleinfo;
    }
    else if (tag == "Imp") {
        //alert(tag);
        PopulateImp();
    }
    else if (tag == "All") {
        //alert(tag);
        PopulatePeople();
    }
    //if (tag == "Pre") {
    //    //alert(tag);
    //    PopulatePre();
    //}
    //if (tag == "After") {
    //    //alert(tag);
    //    PopulateAfter();
    //}
    //if (tag == "In") {
    //    //alert(tag);
    //    PopulateIn();
    //}
    else if (tag == "Upward") {
        //alert(tag);
        PopulateUpward();
    }
    else if (tag == "SPACNews") {
        //alert(tag);
        PopulateSPACNews();
    }
    else if (tag == "IPONews") {
        //alert(tag);
        PopulateIPONews();
    }
    else if (tag == "RecentChange") {
        PopulateRecentChange();
    }
    else if (tag == "GreatValue") {
        PopulateGreatValue();
    }
    else if (tag == "FilterNews") {
        PopulateFilterNews();
    }
    else if (tag == "FilterGreatValueNews") {
        FilterGreatValueNews();
    }
    else if (tag == "FilterFairValueNews") {
        FilterFairValueNews();
    }
    else if (tag == "RecentTop3Ever") {
        RecentTop3Ever();
    }
    else if (tag == "VolumeChange") {
        //alert(tag);
        PopulateVolumeChange();
    }
    else if (tag == "FivePercentFilter") {
        //alert(tag);
        PopulateFivePercent();
    }
    else if (tag == "WSB") {
        //alert(tag);
        PopulateWSB();
    }
    else if (tag == "HTI") {
        //alert(tag);
        PopulateHTI();
    }
    else if (tag == "LOH") {
        //alert(tag);
        PopulateLOH();
    }
    else if (tag == "P01") {
        //alert(tag);
        PopulateP01();
    }
    else if (tag == "P03") {
        //alert(tag);
        PopulateP03();
    }
    else if (tag == "P05") {
        //alert(tag);
        PopulateP05();
    }
    else if (tag == "P10") {
        //alert(tag);
        PopulateP10();
    }
    else if (tag == "News") {
        showTweets = false;
        showNews = true;
        PopulatePeople();
    }
    else if (tag == "Tweets") {
        showTweets = true;
        showNews = false;
        PopulatePeople();
    }
    else {

        PopulatePeople();
    }
    // alert(peopleinfo);
    document.getElementById("demo").innerHTML = peopleinfo;
}