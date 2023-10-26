package com.sandinugraha.apps.amkoscanner.API;

import java.util.concurrent.TimeUnit;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

/**
 * Created by sandinugraha on 26/01/18.
 */

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class ApiClient {
    public static final String BASE_URL = "http://pabbapco401:1010/";
    private static Retrofit retrofit = null;
    private static OkHttpClient okHttpClient = null;

    public static Retrofit getClient() {
        if (retrofit == null) {

            okHttpClient = new OkHttpClient.Builder()
                    .readTimeout(30, TimeUnit.SECONDS)
                    .connectTimeout(30,TimeUnit.SECONDS)
                    .writeTimeout(30,TimeUnit.SECONDS)
                    .build();

            retrofit = new Retrofit.Builder()
                    .baseUrl(BASE_URL)
                    .addConverterFactory(GsonConverterFactory.create())
                    .client(okHttpClient)
                    .build();
        }

        return retrofit;
    }
}