package com.example.intentcalculator;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;

public class Operation extends AppCompatActivity {
    private Intent receiveIntent, sendIntent;
    private int value1, value2;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_operation);

        init();
        startCalc();
    }

    private void init() {
        receiveIntent = getIntent();

        value1 = receiveIntent.getIntExtra("value_first", Integer.MIN_VALUE);
        value2 = receiveIntent.getIntExtra("value_last", Integer.MIN_VALUE);
    }

    private void startCalc() {
        sendIntent = new Intent(getApplicationContext(), MainActivity.class);

        switch (receiveIntent.getIntExtra("operator", Integer.MIN_VALUE)) {
            case 0:
                sendIntent.putExtra("result", value1 + value2);
                setResult(0, sendIntent);
                finish();
                break;
            case 1:
                sendIntent.putExtra("result", value1 - value2);
                setResult(0, sendIntent);
                finish();
                break;
            case 2:
                sendIntent.putExtra("result", value1 * value2);
                setResult(0, sendIntent);
                finish();
                break;
            case 3:
                sendIntent.putExtra("result", value1 / value2);
                setResult(0, sendIntent);
                finish();
                break;
            default:
                Log.println(Log.DEBUG, "operator", String.valueOf(receiveIntent.getIntExtra("operator", Integer.MIN_VALUE)));
                setResult(-1, sendIntent);
                finish();
                break;
        }
    }
}