package com.example.radiobutton;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    Button resultBtn;
    RadioGroup group;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        group = findViewById(R.id.group);
        resultBtn = findViewById(R.id.result);

        resultBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                RadioButton radio = findViewById(group.getCheckedRadioButtonId());
                String string = radio.getText().toString();

                Toast.makeText(getApplicationContext(), string + " 선택됨", Toast.LENGTH_SHORT).show();
            }
        });
    }
}