package com.sandinugraha.apps.amkoscanner.Fragments;


import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.sandinugraha.apps.amkoscanner.API.ApiClient;
import com.sandinugraha.apps.amkoscanner.API.ApiInterface;
import com.sandinugraha.apps.amkoscanner.Adapter.HistoriesAdapter;
import com.sandinugraha.apps.amkoscanner.Model.AssetResponse;
import com.sandinugraha.apps.amkoscanner.Model.HistoryResponse;
import com.sandinugraha.apps.amkoscanner.R;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

import static android.content.ContentValues.TAG;

/**
 * A simple {@link Fragment} subclass.
 */
public class History extends Fragment {

    private String params;


    public History() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_history, container, false);
    }


    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {

        final RecyclerView recyclerView = (RecyclerView) view.findViewById(R.id.history_recycler_view);
        recyclerView.setLayoutManager(new LinearLayoutManager(view.getContext()));

        params = getActivity().getIntent().getStringExtra("code");
        //textView.setText(AssetNumber);

        ApiInterface apiService = ApiClient.getClient().create(ApiInterface.class);

        Call<HistoryResponse> call = apiService.getHistories(params);
        call.enqueue(new Callback<HistoryResponse>() {
            @Override
            public void onResponse(Call<HistoryResponse> call, Response<HistoryResponse> response) {
                List<com.sandinugraha.apps.amkoscanner.Model.History> histories = response.body().getData();
                Log.d(TAG,"Asset Number :" + histories.size());

                recyclerView.setAdapter(new HistoriesAdapter(histories, R.layout.list_history,
                        getActivity().getApplicationContext()));
            }

            @Override
            public void onFailure(Call<HistoryResponse> call, Throwable t) {
                Log.e(TAG,t.toString());
            }
        });

    }





}
