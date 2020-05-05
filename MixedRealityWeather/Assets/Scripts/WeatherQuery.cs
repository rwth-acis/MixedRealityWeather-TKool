using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities.Editor;
using Microsoft.MixedReality.Toolkit.Utilities.Editor.Search;
using System.Threading.Tasks;


namespace Microsoft.MixedReality.Toolkit.Utilities
{
    public class WeatherQuery : MonoBehaviour 
    {
        string apiKey = "16fb128280d16cd1acdeed497976a523";

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public async Task<WeatherData> FetchWeatherData(string cityName)
        {
            WeatherData data = null;

            Response answer = await Rest.GetAsync("api.openweathermap.org / data / 2.5 / weather ? q ={cityName}&appid ={apiKey}");
            if (answer.Successful == true) {
                data = JsonUtility.FromJson<WeatherData>(answer.ResponseBody);
            }

            return data;
        }
    }
}
