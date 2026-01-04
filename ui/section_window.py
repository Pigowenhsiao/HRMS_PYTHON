from ui.crud_base import CrudBaseWindow


class SectionWindow(CrudBaseWindow):
    def __init__(self, dao, translations):
        fields = [
            {
                "name": "dept_code",
                "label_key": "col_dept_code",
                "label_default": "Dept",
                "placeholder_key": "col_dept_code",
                "placeholder_default": "Dept Code",
            },
            {
                "name": "dept_desc",
                "label_key": "col_dept_desc",
                "label_default": "Desc",
                "placeholder_key": "col_dept_desc",
                "placeholder_default": "Description",
            },
        ]
        super().__init__(
            dao,
            translations,
            title_key="section_window_title",
            title_default="部門維護",
            size=(760, 500),
            headers=["dept_code", "dept_desc", "active"],
            header_label_keys=[
                ("col_dept_code", "dept_code"),
                ("col_dept_desc", "dept_desc"),
                ("col_active", "active"),
            ],
            fields=fields,
            checkbox_field={"name": "active", "label_key": "active", "label_default": "Active"},
            key_field="dept_code",
            list_method=dao.list_all_sections,
            create_method=dao.create_section,
            update_method=dao.update_section,
            delete_method=dao.delete_section,
            required_messages={
                "create": ("msg_required_dept", "Dept Code is required"),
                "update": ("msg_required_dept", "Dept Code is required"),
                "delete": ("msg_required_dept", "Dept Code is required"),
            },
            center_columns=[2],
        )
