using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeatherController : MonoBehaviour
{
    public TextMeshPro displayCity;
    public TextMeshPro temperature;
    public TextMeshPro currentWeather;
    public WeatherWidget weatherObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    //converts code from API request to weather scene for widget
    private WeatherScene CodeToWeather(int code)
    {
        WeatherScene currentWeather;

        int firstDigit = (int)(code.ToString()[0]) - 48;
        if (firstDigit == 2)
        {
            currentWeather = WeatherScene.THUNDERSTORM;
        }
        else
        {
            switch (code)
            {
                case 800:
                    currentWeather = WeatherScene.SUNNY;
                    break;
                case 801:
                    currentWeather = WeatherScene.PARTLY_CLOUDY;
                    break;
                case 802:
                    currentWeather = WeatherScene.PARTLY_CLOUDY;
                    break;
                default:
                    currentWeather = WeatherScene.CLOUDY;
                    break;
            }
        }
        return currentWeather;
    }

    //converts code from API request to rain intesity for widget
    private float CodeToRainIntenseity(int code)
    {
        float rainIntensity;

        int firstDigit = (int)(code.ToString()[0]) - 48;
        if (firstDigit == 2)
        {
            rainIntensity = 150f;
        }
        else if (300 <= code && code <= 499){
            rainIntensity = 20f;
        }
        else if (firstDigit == 5)
        {
            rainIntensity = 40f;
        }
        else
        {
            rainIntensity = 0f;
        }
        return rainIntensity;
    }

    //converts code from API request to snow intesity for widget
    private float CodeToSnowIntensity(int code)
    {
        float snowIntensity;
        if (600 <= code && code <= 700)
        {
            snowIntensity = 50f;
        }
        else
        {
            snowIntensity = 0;
        }
        return snowIntensity;
    }

    //requests current weather from server and implements main weather functionallity
    public async void LoadWeather(string cityName)
    {
        WeatherQuery request = GetComponent<WeatherQuery>();
        WeatherData data = await request.FetchWeatherData(cityName);

        if (data != null)
        {
            displayCity.text = cityName;
            temperature.text = string.Format("{0}°",data.main.temp);
            currentWeather.text = data.weather[0].main;

            int weatherId = data.weather[0].id;
            weatherObject.WeatherScene = CodeToWeather(weatherId);
            weatherObject.CloudRain.RainRate = CodeToRainIntenseity(weatherId);
            weatherObject.ThunderstormRain.RainRate = CodeToRainIntenseity(weatherId);
            weatherObject.CloudSnow.RainRate = CodeToSnowIntensity(weatherId);
        }
        else
        {
            throw new System.ArgumentNullException();
        }
    }

}
