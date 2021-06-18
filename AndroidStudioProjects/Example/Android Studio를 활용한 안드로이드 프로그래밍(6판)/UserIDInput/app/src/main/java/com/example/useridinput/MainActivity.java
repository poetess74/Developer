package com.example.useridinput;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    TextView name, email, toastText;
    Button button;
    EditText inputName, inputEmail;
    View dialogView, toastView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("사용자 정보 입력");
        name = findViewById(R.id.tvName);
        email = findViewById(R.id.tvEmail);

        button = findViewById(R.id.button1);

        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                dialogView = View.inflate(MainActivity.this, R.layout.dialog1, null);

                AlertDialog.Builder dig = new AlertDialog.Builder(MainActivity.this);
                dig.setTitle("사용자 정보 입력");
                dig.setIcon(R.mipmap.ic_launcher_round);
                dig.setView(dialogView);

                dig.setPositiveButton("승인",
                        new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                inputName = dialogView.findViewById(R.id.dlgEdt1);
                                inputEmail = dialogView.findViewById(R.id.dlgEdt2);

                                name.setText(inputName.getText().toString());
                                email.setText(inputEmail.getText().toString());
                            }
                        });
                dig.setNegativeButton("취소",
                        new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                Toast toast = new Toast(MainActivity.this);
                                toastView = View.inflate(MainActivity.this, R.layout.toast1, null);
                                toastText = toastView.findViewById(R.id.toastText1);
                                toastText.setText("취소했습니다. ");
                                toast.setView(toastView);
                                toast.show();
                            }
                        });
                dig.show();
            }
        });
    }
}