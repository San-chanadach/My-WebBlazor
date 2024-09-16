using Blazored.Toast.Services;
using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RapidNRIMs.Model.EventRecord;
using RapidNRIMs.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RapidNRIMs.Pages.ComponentBased.MasterDataBased
{
    public class MasterDataProjectTypeBase : ComponentBase
    {
        /// <summary>
        /// listRecordProjectType
        /// </summary>
        protected List<RecordProjectType> listRecordProjectType = new List<RecordProjectType>();
        protected RecordProjectType addProjectType = new RecordProjectType();
        protected RecordProjectType editProjectType = new RecordProjectType();


        /// <summary>
        /// BSModal
        /// </summary>
        protected BSModal Load { get; set; }
        protected BSModal ModalResponseError { get; set; }
        protected BSModal ModalRespondSuccess { get; set; }
        protected BSModal ModalProjectTypeCreate { get; set; }
        protected BSModal ModalProjectTypeEdit { get; set; }
        protected BSModal ModalProjectTypeDelete { get; set; }

        /// <summary>
        /// Variable
        /// </summary>
        protected string RequertMessage;

        [Inject]
        protected AppData AppData { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        [Inject]
        protected IJSRuntime jsRuntime { get; set; }
        [Inject]
        protected IToastService ToastService { get; set; }
        [Inject]
        protected IMasterDataPhase2 _masterDataPhase2 { get; set; }


        /// <summary>
        /// OnInitializedAsync
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            try
            {
                AppData.recordProjectTypes = await _masterDataPhase2.GetMasterDataAsync<RecordProjectType>("ProjectType");
                listRecordProjectType = AppData.recordProjectTypes;
                //await jsRuntime.InvokeAsync<object>("ThisDataTablesAdd");
            }
            catch (Exception e)
            {
                var val = e.Message;
                RequertMessage = val;
            }
        }

        /// <summary>
        /// Modal show ProjectTypeUpdate
        /// </summary>
        /// <param name="id"></param>
        protected async void ProjectTypeUpdate(int id)
        {
            try
            {
                var respond = await _masterDataPhase2.GetMasterDataAsyncByID<RecordProjectType>("ProjectTypeByID", id);
                if (string.IsNullOrEmpty(respond.Content))
                {
                    editProjectType = respond;
                    ModalProjectTypeEdit.Show();
                }
                else
                {
                    var requertException = respond.Content;
                    RequertMessage = requertException;
                    ModalResponseError.Show();
                }
            }
            catch (Exception e)
            {
                var val = e.Message;
                RequertMessage = val;
                ModalResponseError.Show();
            }
        }

        /// <summary>
        /// Modal show ProjectTypeDelete
        /// </summary>
        /// <param name="id"></param>
        protected async void ProjectTypeDelete(int id)
        {
            try
            {
                var respond = await _masterDataPhase2.GetMasterDataAsyncByID<RecordProjectType>("ProjectTypeByID", id);
                if (string.IsNullOrEmpty(respond.Content))
                {
                    editProjectType = respond;
                    ModalProjectTypeDelete.Show();
                }
                else
                {
                    var requertException = respond.Content;
                    RequertMessage = requertException;
                    ModalResponseError.Show();
                }
            }
            catch (Exception e)
            {
                var val = e.Message;
                RequertMessage = val;
                ModalResponseError.Show();
            }
        }

        /// <summary>
        /// SaveCreateProjectType
        /// </summary>
        protected async Task SaveCreateProjectType()
        {
            try
            {
                var respond = await _masterDataPhase2.PostMasterDataAsync("PostProjectType", addProjectType);
                if (!string.IsNullOrEmpty(respond.ToString()))
                {
                    var requertException = respond.StatusMessage;
                    RequertMessage = requertException;
                    await OnInitializedAsync();
                    ModalRespondSuccess.Show();
                }
                else
                {
                    var requertException = respond.Content;
                    RequertMessage = requertException;
                    ModalResponseError.Show();
                }

            }
            catch (Exception e)
            {
                var val = e.Message;
                RequertMessage = val;
                ModalResponseError.Show();
            }
            ModalProjectTypeCreate.Hide();
        }

        /// <summary>
        /// SaveEditProjectType
        /// </summary>
        protected async Task SaveEditProjectType()
        {
            try
            {
                var respond = await _masterDataPhase2.PutMasterDataAsync("PutProjectType", editProjectType, editProjectType.ProjectTypeID);
                if (!string.IsNullOrEmpty(respond.ToString()))
                {
                    var requertException = respond.StatusMessage;
                    RequertMessage = requertException;
                    await OnInitializedAsync();
                    ModalRespondSuccess.Show();
                }
                else
                {
                    var requertException = respond.Content;
                    RequertMessage = requertException;
                    ModalResponseError.Show();
                }
            }
            catch (Exception e)
            {
                var val = e.Message;
                RequertMessage = val;
                ModalResponseError.Show();
            }
            ModalProjectTypeEdit.Hide();
        }

        /// <summary>
        /// SaveDeleteProjectType
        /// </summary>
        protected async Task SaveDeleteProjectType()
        {
            try
            {
                var respond = await _masterDataPhase2.DeleteMasterDataAsync<RecordProjectType>("DeleteProjectType", editProjectType.ProjectTypeID);
                if (!string.IsNullOrEmpty(respond.ToString()))
                {
                    var requertException = respond.StatusMessage;
                    RequertMessage = requertException;
                    await OnInitializedAsync();
                    ModalRespondSuccess.Show();
                }
                else
                {
                    var requertException = respond.Content;
                    RequertMessage = requertException;
                    ModalResponseError.Show();
                }
            }
            catch (Exception e)
            {
                var val = e.Message;
                RequertMessage = val;
                ModalResponseError.Show();
            }
            ModalProjectTypeDelete.Hide();
        }

        /// <summary>
        /// ClearCreateProjectType
        /// </summary>
        protected void ClearCreateProjectType()
        {
            addProjectType = new RecordProjectType();
        }
    }
}
