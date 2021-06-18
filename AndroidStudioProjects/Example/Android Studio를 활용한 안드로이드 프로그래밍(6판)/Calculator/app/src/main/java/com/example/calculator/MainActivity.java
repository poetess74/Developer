package com.example.calculator;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    EditText[] editor = new EditText[2];
    Button[] buttons = new Button[5];
    TextView output;
    String[] input = new String[2];
    int result;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("초간단 계산기");

        editor[0] = findViewById(R.id.dividend);
        editor[1] = findViewById(R.id.sacrifices);

        buttons[0] = findViewById(R.id.addBtn);
        buttons[1] = findViewById(R.id.subBtn);
        buttons[2] = findViewById(R.id.mulBtn);
        buttons[3] = findViewById(R.id.divBtn);
        buttons[4] = findViewById(R.id.modBtn);
        Context context = getApplicationContext();

        output = findViewById(R.id.result);

        for(int i = 0; i < buttons.length; i++) {
            int finalI = i;
            buttons[i].setOnClickListener(new View.OnClickListener() {
                public void onClick(View v) {
                    if(editor[0].getText().toString().equals("") || editor[1].getText().toString().equals("")) {
                        Toast myToast = Toast.makeText(context, "값이 없습니다", Toast.LENGTH_SHORT);
                        myToast.show();
                        return;
                    }

                    input[0] = editor[0].getText().toString();
                    input[1] = editor[1].getText().toString();
                    switch (finalI) {
                        case 0:
                            result = Integer.parseInt(input[0]) + Integer.parseInt(input[1]);
                            output.setText("계산 결과: " + result);
                            break;
                        case 1:
                            result = Integer.parseInt(input[0]) - Integer.parseInt(input[1]);
                            output.setText("계산 결과: " + result);
                            break;
                        case 2:
                            result = Integer.parseInt(input[0]) * Integer.parseInt(input[1]);
                            output.setText("계산 결과: " + result);
                            break;
                        case 3:
                            try {
                                result = Integer.parseInt(input[0]) / Integer.parseInt(input[1]);
                            } catch (Exception e) {
                                Toast myToast = Toast.makeText(context, "0으로 나눌 수 없습니다. ", Toast.LENGTH_SHORT);
                                myToast.show();
                                return;
                            }
                            output.setText("계산 결과: " + result);
                            break;
                        case 4:
                            try {
                                result = Integer.parseInt(input[0]) % Integer.parseInt(input[1]);
                            } catch (Exception e) {
                                Toast myToast = Toast.makeText(context, "0으로 나눌 수 없습니다. ", Toast.LENGTH_SHORT);
                                myToast.show();
                                return;
                            }
                            output.setText("계산 결과: " + result);
                            break;
                    }
                }
            });
        }
    }
}