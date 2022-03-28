function GetPeopleInfo(people) {
    try {

        GreatValueTag = "<span style='color: Green; font-weight:bold'>Great</span>&nbsp; &nbsp;";
        RiskValueTag = "<span style='color:red; font-weight:bold' >Risk</span>&nbsp; &nbsp;";
        FairValueTag = "<span style='color: deeppink ; font-weight:bold' >Fair</span>&nbsp; &nbsp;";

        CheckTag = "<input type='checkbox' id='check5' class='save-cb-state' value='Python'>";
        NewTag = "<span style='color: Purple; font-weight:bold'>New</span>&nbsp; &nbsp;";
        ChangeTag = "<span style='color: Orange; font-weight:bold'>Change</span>&nbsp; &nbsp;";
        WeBullTag = "<span style='color: Purple; font-weight:bold'>We Bull</span>&nbsp; &nbsp;";
        TradingViewTag = "<span style='color: Brown; font-weight:bold'>Trading View</span>&nbsp; &nbsp;";
        peopleinfo = "";
        var percentcheck = 0;

        var dt = new Date(people.PubDate);
        //alert(dt.getDate());
        var checkToday = true;
        var checkallhours = true;
        var checkallPlatform = true;
        var checkAllWithTweeted = true;
        var checkallRecomended = true;
        var checkAllWithNew = true;
        var checkAllWithBio = true;
        var checkAllWithLowFloat = true;

        //alert(selectedToday);
        if (selectedToday) {
            checkToday = (dt != null && (dt.getDate() === today.getDate() || dt.getDate() === (today.getDate())) &&
                dt.getMonth() === today.getMonth() &&
                dt.getFullYear() === today.getFullYear());
        }
        else if (selectedTodayYesterday) {
            checkToday = (dt != null && (dt.getDate() === today.getDate() || dt.getDate() === (today.getDate() - 1)) &&
                dt.getMonth() === today.getMonth() &&
                dt.getFullYear() === today.getFullYear());
        }
        //selectedTradinghours = 'PreMarket'

        if (selectedTradinghours == 'Trading') {
            percentcheck = people.PercentChange;
        }
        else if (selectedTradinghours == 'After') {
            percentcheck = people.PercentChangeAfterTradingHours;
        }
        //else if (selectedTradinghours == 'Recent') {
        //    percentcheck = people.PercentChangeSinceLast;
        //}
        else if (selectedTradinghours == 'PreMarket') {
            percentcheck = people.PercentChangePreTradingHours;
        }
        else {
            percentcheck = people.PercentChange;
        }
        //debugger;
        if (selectedPlatform == 'Webull') {
            if (!people.isWeBullResult) {
                checkallPlatform = false;
            }
        }
        else if (selectedPlatform == 'TradingView') {
            if (!people.isTradingViewResult) {
                checkallPlatform = false;
            }
        }


        //if (selectedShortCut == 'Recent') {
        //    percentcheck = people.PercentChangeSinceLast;
        //}



        if (selectedTimeHour) {
            if (!people.isLastOnehourNews) {
                checkallhours = false;
            }
        }

        //if (people.Symbol == 'SBEV') {
        //    alert(selectedTradinghours);
        //    //alert(people.PercentChangeAfterTradingHours);
        //}
        if (selectedRecomended) {
            if (percentcheck >= 11) {//|| percentcheck <= 3) {
                checkallRecomended = false;
            }
        }

        if (selectedBio) {
            if (people.isBioNews) {
                checkAllWithBio = false;
            }
        }

        //if (selectedTweeted) {
        //    if (!people.isTweeted) {
        //        checkAllWithTweeted = false;
        //    }
        //}

        if (selectedNew) {
            if (!people.isNewlyAdded) {
                checkAllWithNew = false;
            }
        }
        if (selectedLowFloat) {
            if (!people.isLowFloat) {
                checkAllWithLowFloat = false;
            }
        }
        if (!people.NewsLink.includes(".com")) {
            people.NewsLink = "https://stockhouse.com" + people.NewsLink
        }

        allnews = '';
        try {
            if (people.AllNews && people.AllNews.length > 0) {
                for (j = 0; j < people.AllNews.length; j++) {
                    allnews = allnews + "<br>"
                    allnews = allnews + "&nbsp; &nbsp;" + "<a style='color: blue ; font-weight:bold' href=" + people.AllNews[j].NewsLink + " target=_blank >" + people.AllNews[j].Title + "</a> &nbsp; &nbsp; "
                    if (j == 5) {
                        break;
                    }
                }
            }

            else {
                allnews = allnews + "<br>"
                allnews = allnews + "&nbsp; &nbsp;" + "<a style='color: blue ; font-weight:bold' href=" + people.NewsLink + " target=_blank >" + people.Title + "</a> &nbsp; &nbsp; "
            }
        } catch (error) {
            debugger;
            console.error(error);
            // expected output: ReferenceError: nonExistentFunction is not defined
            // Note - error messages will vary depending on browser
        }

        alltweets = '';
        try {
            if (people.AllTweets && people.AllTweets.length > 0) {
                alltweets = "<br>" + "<B>Tweets</B> :"
                for (j = 0; j < people.AllTweets.length; j++) {
                    alltweets = alltweets + "<br>"
                    alltweets = alltweets + "&nbsp; &nbsp;<B>" + people.AllTweets[j].Title + " </B>&nbsp; &nbsp; "
                    if (j == 5) {
                        break;
                    }
                }
            }
        } catch (error) {
            debugger;
            console.error(error);
            // expected output: ReferenceError: nonExistentFunction is not defined
            // Note - error messages will vary depending on browser
        }

        //!people.isNoNews &&
        if (checkAllWithBio && checkallPlatform && checkallRecomended && checkAllWithNew && checkAllWithLowFloat && checkallhours && checkToday && percentcheck >= minPercent && percentcheck <= maxPercent) {
            //peopleinfo = "<input type='checkbox' id='check5' class='save-cb-state' name=' " + people.Symbol + "'> "
            // peopleinfo = "&nbsp; &nbsp;" + "<a href=" + people.NewsLink + " target=_blank >" + people.Title + "</a> &nbsp; &nbsp; "


            if (selectedTradinghours == 'Trading') {
                peopleinfo = peopleinfo + "<a style='font-weight:bold' href=" + people.WatchUri + " target=_blank  > In " + people.PercentChange + "%</a> &nbsp; &nbsp; "
            }
            else if (selectedTradinghours == 'After') {
                peopleinfo = peopleinfo + "<a style='font-weight:bold' href=" + people.WatchUri + " target=_blank  > After " + people.PercentChange + "%</a> &nbsp; &nbsp; "
            }
            else if (selectedTradinghours == 'PreMarket') {
                peopleinfo = peopleinfo + "<a style='font-weight:bold' href=" + people.WatchUri + " target=_blank  > Pre " + people.PercentChange + "%</a> &nbsp; &nbsp; "
            }

            peopleinfo = peopleinfo

                /* + "<a href=" + people.WatchUri + " target=_blank  >" + people.PercentChange + "%</a> &nbsp; &nbsp; "*/
                + "<a style='font-weight:bold' href=" + people.WatchUri + " target=_blank > Recent " + people.PercentChangeSinceLast + "%</a> &nbsp; &nbsp; "
                + "<a style='font-weight:bold' href=" + people.WatchUri + " target=_blank  >$" + people.MarketPrice + "</a> &nbsp; &nbsp; "

                + people.PubDate + "&nbsp; &nbsp; " /*+ "(" + get_time_diff(people.PubDate) + ")*/
                + "<a style='font-weight:bold' href=" + people.NewsSourceLink + " target=_blank  >" + people.CompanyName + "</a> &nbsp; &nbsp; "
                + "<a style='font-weight:bold' href=" + people.RobinNews + " target=_blank  >" + people.Symbol + "</a> &nbsp; &nbsp; "
                + "<a href=" + people.WatchUri + " target=_blank  > Shares :" + convertToInternationalCurrencySystem(people.OutStandingShares) + "</a> &nbsp; &nbsp; "
                + "<a href=" + people.WatchUri + " target=_blank  > Vol : " + convertToInternationalCurrencySystem(people.AverageVolume) + "</a> &nbsp; &nbsp; "
                + "<a href=" + people.WatchUri + " target=_blank  > Vol Change: " + convertToInternationalCurrencySystem(people.AverageVolumeChangeSinceLast) + "</a> &nbsp; &nbsp; "
                + "<a href=" + people.WatchUri + " target=_blank  > MCap : " + convertToInternationalCurrencySystem(people.MarketCap) + "</a> &nbsp; &nbsp; "
            if (showNews) {
                peopleinfo = peopleinfo + allnews
            }
            if (showTweets) {
                peopleinfo = peopleinfo + alltweets
            }
            //+ "&nbsp; &nbsp;" + "<a style='color: blue ; font-weight:bold' href=" + people.NewsLink + " target=_blank >" + people.Title + "</a> &nbsp; &nbsp; "
            // + "<br>"


            /* + "<br />"*/


            peopleinfo = peopleinfo + "<br />"
                + "<a href=" + people.WatchUri + " target=_blank  > 50DayMin : $" + people.FiftyDayMin + "</a> &nbsp; &nbsp; "
                + "<a href=" + people.WatchUri + " target=_blank  > 50DayMax : $" + people.FiftyDayMax + "</a> &nbsp; &nbsp; "

                + "<a href=" + people.NewsSourceGoogleFinanceLink + " target=_blank  >GL</a> &nbsp; &nbsp; "
                + "<a href=" + people.NewsSourceBenzingLink + " target=_blank  >BZ</a> &nbsp; &nbsp; "
                + "<a href=" + people.NewsSourceBarronsLink + " target=_blank  >BR</a> &nbsp; &nbsp; "
                + "<a href=" + people.NewsSourceWeBullLink + " target=_blank  >BULL</a> &nbsp; &nbsp; "
                + "<a href=" + people.NewsSourceMarketBeatLink + " target=_blank  >MB</a> &nbsp; &nbsp; "
                + "<a href=" + people.NewsSourceStockHouseLink + " target=_blank  >STK</a> &nbsp; &nbsp; "
                + "<a href=" + people.NewsSourceMarketWatchLink + " target=_blank  >MW</a> &nbsp; &nbsp; "
                + "<a href=" + people.NewsSourceMarketChameleonLink + " target=_blank  >MC</a> &nbsp; &nbsp; "
                + "<a href=" + people.TwitterLink + " target=_blank  >TWT</a> &nbsp; &nbsp; "
                + "<a href=" + people.StockTwitsLink + " target=_blank  >STKTWT</a> &nbsp; &nbsp; "

                + "<a href=" + people.WatchUri + " target=_blank  >" + people.Industry + "</a> &nbsp; &nbsp; "
                + "<a href=" + people.WatchUri + " target=_blank  >" + people.isBioNews + "</a> &nbsp; &nbsp; "
                + "<a href=" + people.WatchUri + " target=_blank  >" + people.TradingHour + "</a> &nbsp; &nbsp; "
                // + "<a href=" + people.WatchUri + " target=_blank  >" + people.Sector + "</a> &nbsp; &nbsp; "
                + people.StockAdditionDate + "&nbsp; &nbsp; " /*+ "(" + get_time_diff(people.PubDate) + ")*/;

        }
        if (peopleinfo != '' && people.FiftyDayMin > 0 && people.MarketPrice > 0 && (Math.round(((people.MarketPrice - people.FiftyDayMin) / people.FiftyDayMin) * 100) < GreatValuePercent)) {
            peopleinfo = GreatValueTag + peopleinfo;
        }

        if (peopleinfo != '' && people.FiftyDayMin > 0 && people.MarketPrice > 0 && (Math.round(((people.MarketPrice - people.FiftyDayMin) / people.FiftyDayMin) * 100) > FairValuePercent)
            && (Math.round(((people.MarketPrice - people.FiftyDayMin) / people.FiftyDayMin) * 100) < 60)) {
            peopleinfo = FairValueTag + peopleinfo;
        }

        if (peopleinfo != '' && people.FiftyDayMin > 0 && people.MarketPrice > 0 && (Math.round(((people.MarketPrice - people.FiftyDayMin) / people.FiftyDayMin) * 100) > RiskValuePercent)) {
            peopleinfo = RiskValueTag + peopleinfo;
        }

        if (peopleinfo != '' && people.isNewlyAdded) {
            peopleinfo = NewTag + peopleinfo;
        }
        if (peopleinfo != '' && people.PercentChangeSinceLast > 0) {
            peopleinfo = ChangeTag + peopleinfo;
        }
        if (peopleinfo != '' && people.isWeBullResult) {
            peopleinfo = peopleinfo + WeBullTag;
        }
        if (peopleinfo != '' && people.isTradingViewResult) {
            peopleinfo = peopleinfo + TradingViewTag;
        }
        if (peopleinfo != '') {
            peopleinfo = peopleinfo + "<br><p>********</p>";
        }
    }
    catch (error) {
        alert(error);
        // expected output: ReferenceError: nonExistentFunction is not defined
        // Note - error messages will vary depending on browser
    }
    return peopleinfo;
}