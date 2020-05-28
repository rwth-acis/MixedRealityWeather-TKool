using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities.Editor;
using Microsoft.MixedReality.Toolkit.Utilities.Editor.Search;
using System.Threading.Tasks;



    public class WeatherQuery : MonoBehaviour 
    {
        private static string apiKey = "16fb128280d16cd1acdeed497976a523";

        public async Task<WeatherData> FetchWeatherData(string cityName)
        {
            WeatherData data = null;
            Microsoft.MixedReality.Toolkit.Utilities.Response answer = await Microsoft.MixedReality.Toolkit.Utilities.Rest.GetAsync(string.Format("api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", cityName, apiKey));
            if (answer.Successful == true) {
                Debug.Log("Recived Weather Information.");
                data = JsonUtility.FromJson<WeatherData>(answer.ResponseBody);
            }
        else
        {
            Debug.Log("weather data could not be fetched");
        }

            return data;
        }
    }
