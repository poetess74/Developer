package com.example.improvedcalculator;

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
    Button[] operator = new Button[5];
    Button[] keypad = new Button[10];
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

        int[] op = new int[] {R.id.addBtn, R.id.subBtn, R.id.mulBtn, R.id.divBtn, R.id.modBtn};
        for(int i = 0; i < operator.length; i++) {
            operator[i] = findViewById(op[i]);
        }

        int[] key = new int[] {
                R.id.btnNum0, R.id.btnNum1, R.id.btnNum2,
                R.id.btnNum3, R.id.btnNum4, R.id.btnNum5,
                R.id.btnNum6, R.id.btnNum7, R.id.btnNum8, R.id.btnNum9
        };
        for(int i = 0; i < keypad.length; i++) {
            keypad[i] = findViewById(key[i]);
        }

        final Context context = getApplicationContext();

        output = findViewById(R.id.result);

        for(int i = 0; i < operator.length; i++) {
            final int index = i;
            operator[i].setOnClickListener(new View.OnClickListener() {
                public void onClick(View v) {
                    if(editor[0].getText().toString().equals("") || editor[1].getText().toString().equals("")) {
                        Toast myToast = Toast.makeText(context, "값이 없습니다", Toast.LENGTH_SHORT);
                        myToast.show();
                        return;
                    }

                    input[0] = editor[0].getText().toString();
                    input[1] = editor[1].getText().toString();
                    switch (index) {
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

        for(int i = 0; i < keypad.length; i++) {
            final int index = i;
            keypad[index].setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    if(editor[0].isFocused()) {
                        input[0] = editor[0].getText().toString() + keypad[index].getText().toString();
                        editor[0].setText(input[0]);
                    } else if(editor[1].isFocused()) {
                        input[1] = editor[1].getText().toString() + keypad[index].getText().toString();
                        editor[1].setText(input[1]);
                    } else {
                        Toast.makeText(getApplicationContext(), "에디트박스에 값을 입력하세요. ", Toast.LENGTH_SHORT).show();
                    }
                }
            });
        }
    }
}