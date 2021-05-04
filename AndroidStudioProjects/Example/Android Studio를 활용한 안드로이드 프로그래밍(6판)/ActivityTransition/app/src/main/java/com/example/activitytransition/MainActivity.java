package com.example.activitytransition;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.RadioButton;
import android.widget.RadioGroup;

public class MainActivity extends AppCompatActivity {
    RadioGroup group;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        group = findViewById(R.id.rgGroup);
    }

    public void onMainButtonClicked(View view) {
        Intent intent;
        RadioButton radioButton = findViewById(group.getCheckedRadioButtonId());

        switch (radioButton.getId()) {
            case R.id.radioButton1:
                intent = new Intent(getApplicationContext(), SecondActivity.class);
                intent.putExtra("title", "Main 화면에서 Second 화면 호출");
                startActivity(intent);
                break;
            case R.id.radioButton2:
                intent = new Intent(getApplicationContext(), ThirdActivity.class);
                intent.putExtra("title", "Main 화면에서 Third 화면 호출");
                startActivity(intent);
                break;
            default:
                break;
        }
    }
}