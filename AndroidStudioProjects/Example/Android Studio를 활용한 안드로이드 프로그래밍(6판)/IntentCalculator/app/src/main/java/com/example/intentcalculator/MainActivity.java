package com.example.intentcalculator;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioGroup;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    private Intent sendIntent;
    private RadioGroup operator;
    private Button calc;
    private EditText inputA, inputB;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        init();
        setAction();
    }

    private void init() {
        inputA = findViewById(R.id.firstNum);
        inputB = findViewById(R.id.secondNum);
        operator = findViewById(R.id.operatorGroup);
        calc = findViewById(R.id.calcButton);
    }

    private void setAction() {
        calc.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                sendIntent = new Intent(getApplicationContext(), Operation.class);
                sendIntent.putExtra("value_first", Integer.parseInt(inputA.getText().toString()));
                sendIntent.putExtra("value_last",  Integer.parseInt(inputB.getText().toString()));
                sendIntent.putExtra("operator",  operator.indexOfChild(findViewById(operator.getCheckedRadioButtonId())));
                startActivityForResult(sendIntent, 0);
            }
        });
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if(requestCode == 0) {
            Toast.makeText(getApplicationContext(),
                    String.format("결과: %d", data.getIntExtra("result", Integer.MIN_VALUE)),
                    Toast.LENGTH_SHORT).show();
        } else {
           Toast.makeText(getApplicationContext(), "계산 중 에러 발생", Toast.LENGTH_LONG).show();
        }
    }
}