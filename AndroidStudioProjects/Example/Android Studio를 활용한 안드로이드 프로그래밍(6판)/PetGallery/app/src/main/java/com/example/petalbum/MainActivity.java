package com.example.petalbum;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.ImageView;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    TextView question;
    CheckBox agreement;
    RadioGroup petGroup;
    Button inputDone;
    ImageView result;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        init();

        agreement.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                question.setVisibility(agreement.isChecked() ? View.VISIBLE : View.INVISIBLE);
                petGroup.setVisibility(agreement.isChecked() ? View.VISIBLE : View.INVISIBLE);
                inputDone.setVisibility(agreement.isChecked() ? View.VISIBLE : View.INVISIBLE);
                result.setVisibility(agreement.isChecked() ? View.VISIBLE : View.INVISIBLE);

                if(agreement.isChecked()) {
                    Toast.makeText(getApplicationContext(), "세 항목중 하나를 선택하세요. ", Toast.LENGTH_SHORT).show();
                } else {
                    petGroup.clearCheck();
                }
            }
        });

        inputDone.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                switch (petGroup.getCheckedRadioButtonId()) {
                    case R.id.dog: result.setImageResource(R.drawable.dog); break;
                    case R.id.cat: result.setImageResource(R.drawable.cat); break;
                    case R.id.rabbit: result.setImageResource(R.drawable.rabbit); break;
                    default:
                        Toast.makeText(getApplicationContext(), "동물을 먼저 선택하세요. ", Toast.LENGTH_SHORT).show();
                        break;
                }
            }
        });
    }

    private void init() {
        agreement = findViewById(R.id.agreement);

        question = findViewById(R.id.questionText);
        petGroup = findViewById(R.id.petGroup);

        inputDone = findViewById(R.id.inputDone);
        result = findViewById(R.id.result);
    }
}