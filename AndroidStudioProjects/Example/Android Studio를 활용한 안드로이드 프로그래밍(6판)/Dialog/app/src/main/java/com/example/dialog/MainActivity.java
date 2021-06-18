package com.example.dialog;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {
    Button[] buttons = new Button[4];
    String[] versionArray = new String[] { "Pie", "Q", "R" };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        buttons[0] = findViewById(R.id.basic);
        buttons[1] = findViewById(R.id.list);
        buttons[2] = findViewById(R.id.radio);
        buttons[3] = findViewById(R.id.checkbox);

        buttons[0].setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                AlertDialog.Builder dig = new AlertDialog.Builder(MainActivity.this);
                dig.setTitle("좋아하는 버전은?");
                dig.setIcon(R.mipmap.ic_launcher);
                dig.setPositiveButton("승인", null);
//                dig.setNeutralButton("승인", null);
                dig.show();
            }
        });

        buttons[1].setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                AlertDialog.Builder dig = new AlertDialog.Builder(MainActivity.this);
                dig.setTitle("좋아하는 버전은?");
                dig.setIcon(R.mipmap.ic_launcher);
                dig.setItems(versionArray,
                        new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                buttons[1].setText(versionArray[which]);
                            }
                        });
                dig.setPositiveButton("승인", null);
                dig.show();
            }
        });

        buttons[2].setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                AlertDialog.Builder dig = new AlertDialog.Builder(MainActivity.this);
                dig.setTitle("좋아하는 버전은?");
                dig.setIcon(R.mipmap.ic_launcher);
                dig.setSingleChoiceItems(versionArray, 0,
                        new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                buttons[2].setText(versionArray[which]);
                            }
                        });
                dig.setPositiveButton("승인", null);
                dig.show();
            }
        });

        buttons[3].setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                final boolean[] checkArray = new boolean[] { true, false, false };
                AlertDialog.Builder dig = new AlertDialog.Builder(MainActivity.this);
                dig.setTitle("좋아하는 버전은?");
                dig.setIcon(R.mipmap.ic_launcher);
                dig.setMultiChoiceItems(versionArray, checkArray,
                        new DialogInterface.OnMultiChoiceClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which, boolean isChecked) {
                                buttons[3].setText(versionArray[which]);
                            }
                        });
                dig.setPositiveButton("승인", null);
                dig.show();
            }
        });
    }
}