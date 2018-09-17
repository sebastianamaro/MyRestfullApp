
function Longest_Country_Name(countryArray) {
    
    if(countryArray.length > 0) {
        var longestCountryValue = countryArray[0];
        for(var i = 1;i<countryArray.length;i++){
            if(countryArray[i].length > longestCountryValue.length)
                longestCountryValue= countryArray[i];
        }

        console.log("Longest Country: " + longestCountryValue);
    }
    else {
        console.log("No countries on input!");
    }
  
    
}

Longest_Country_Name(["Australia", "Germany", "United States of America"])
