from ui.crud_base import CrudBaseWindow


class JobWindow(CrudBaseWindow):
    def __init__(self, dao, translations):
        fields = [
            {
                "name": "l_job",
                "label_key": "col_l_job",
                "label_default": "Job",
                "placeholder_key": "col_l_job",
                "placeholder_default": "Job Code",
            },
            {
                "name": "l_job_desc",
                "label_key": "col_l_job_desc",
                "label_default": "Desc",
                "placeholder_key": "col_l_job_desc",
                "placeholder_default": "Description",
            },
        ]
        super().__init__(
            dao,
            translations,
            title_key="job_window_title",
            title_default="職務/Function 維護",
            size=(700, 480),
            headers=["l_job", "l_job_desc", "active"],
            header_label_keys=[
                ("col_l_job", "l_job"),
                ("col_l_job_desc", "l_job_desc"),
                ("col_active", "active"),
            ],
            fields=fields,
            checkbox_field={"name": "active", "label_key": "active", "label_default": "Active"},
            key_field="l_job",
            list_method=dao.list_all_jobs,
            create_method=dao.create_job,
            update_method=dao.update_job,
            delete_method=dao.delete_job,
            required_messages={
                "create": ("msg_required_job", "請輸入職務代碼"),
                "update": ("msg_required_job_select", "請先選擇或輸入職務代碼"),
                "delete": ("msg_required_job_select", "請先選擇或輸入職務代碼"),
            },
            center_columns=[2],
        )
        self.job = self.l_job
        self.job_desc = self.l_job_desc
