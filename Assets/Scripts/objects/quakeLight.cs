using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class quakeLight : MonoBehaviour
{
    public int choice = 1;


    int frame_rate = 10;
    float frame_amount;
    float light_intensity;
    float starting_light_intensity;

    int i = 0;

    Coroutine light_flicker;


    // Start is called before the first frame update
    void Start()
    {
        starting_light_intensity = gameObject.GetComponent<Light>().intensity;

        lightSetting(choice, 10);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator light_flash(float fa, string light_setting)
    {
        
        while (true)
        {
            light_intensity = ((float)light_setting[i] -97) / 26;
            
            gameObject.GetComponent<Light>().intensity = light_intensity * starting_light_intensity;
            yield return new WaitForSeconds(fa);

            i++;
            if (i > (light_setting.Length - 1))
            {
                i = 0;
            }       
        }
        
    }

    
    public void lightSetting(int i, int fa)
    {
        string light_string;

        switch (i)
        {
            //  normal          (DEFAULT STATE)
            case 1: light_string = "m"; break;

            //  flicker 1
            case 2: light_string = "mmnmmommommnonmmonqnmmo"; break;

            //  flicker 2
            case 3: light_string = "nmonqnmomnmomomno"; break;

            //  fast strobe
            case 4: light_string = "mamamamamama"; break;

            //  slow strobe
            case 5: light_string = "aaaaaaaazzzzzzzz"; break;

            //  slow strong pulse
            case 6: light_string = "abcdefghijklmnopqrstuvwxyzyxwvutsrqponmlkjihgfedcba"; break;

            //  slow pulse not fade to black
            case 7: light_string = "abcdefghijklmnopqrrqponmlkjihgfedcba"; break;

            //  gentle pulse
            case 8: light_string = "jklmnopqrstuvwxyzyxwvutsrqponmlkj"; break;

            //  candle 1
            case 9: light_string = "mmmmmaaaaammmmmaaaaaabcdefgabcdefg"; break;

            //  candle 2
            case 10: light_string = "mmmaaaabcdefgmmmmaaaammmaamm"; break;

            //  candle 3
            case 11: light_string = "mmmaaammmaaammmabcdefaaaammmmabcdefmmmaaaa"; break;

            //  candle 3
            case 12: light_string = "mmmkjjsmmmkkkmmmghijffffmmmmfghimmmdddd"; break;

            //  fluorescent flicker
            case 13: light_string = "mmamammmmammamamaaamammma"; break;

            default:                light_string = "a";                break;
        }

        frame_amount = 1f / fa;

        light_flicker = StartCoroutine(light_flash(frame_amount, light_string));  
    }
}
