package com.example.checkbox;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        CheckBox[] checkBoxes = new CheckBox[3];

        checkBoxes[0] = findViewById(R.id.dog);
        checkBoxes[1] = findViewById(R.id.cat);
        checkBoxes[2] = findViewById(R.id.rabbit);

        Button checkoutBtn = findViewById(R.id.print);

        checkoutBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String string = "";

                if(checkBoxes[0].isChecked()) string += checkBoxes[0].getText().toString();
                if(checkBoxes[1].isChecked()) string += checkBoxes[1].getText().toString();
                if(checkBoxes[2].isChecked()) string += checkBoxes[2].getText().toString();

                Toast.makeText(getApplicationContext(), string, Toast.LENGTH_LONG).show();
            }
        });
    }
}